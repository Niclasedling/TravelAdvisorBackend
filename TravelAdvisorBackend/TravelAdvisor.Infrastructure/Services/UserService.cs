using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;

using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserCreateDto> Create(UserCreateDto newUser)
        {
            var user = _mapper.Map<User>(newUser);


            var users = await _unitOfWork.UserRepository.GetAllAsync();

            var isUserExists = users.FirstOrDefault(item => item.Email == newUser.Email);

            if (isUserExists == null)
            {
                await _unitOfWork.UserRepository.AddAsync(user);

                var newUserDto = _mapper.Map<UserCreateDto>(user);

                await _unitOfWork.SaveChanges();

                return newUserDto;
            }
            else
            {
                throw new Exception("User with the email already exists");
            }


        }
        public async Task<UserLoginDto> Login(UserLoginDto userLogin)
        {
            //var user = _mapper.Map<User>(userLogin);

            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var user = users.FirstOrDefault(item => item.Email == userLogin.Email && item.Password == userLogin.Password);
            UserLoginDto userLoginDto = new UserLoginDto() { Email = user.Email, Password = user.Password };

            if (user == null)
            {
                throw new Exception("Wrong email or password");
            }

            return userLoginDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByGuidAsync(id);
            bool correct = false;
            if (user != null)
            {
                await _unitOfWork.UserRepository.RemoveAsync(user);
                await _unitOfWork.SaveChanges();
                correct = true;

            }

            return correct;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            if(users != null)
            {
                var mappedUsers = _mapper.Map<List<UserDto>>(users);
                return mappedUsers;
            }
            return null; //Lägg till felmeddelande
        }

        public Task<UserDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<UserUpdateDto> Update(UserUpdateDto userUpdateDto)
        {   
            if (userUpdateDto == null) throw new ArgumentNullException(nameof(userUpdateDto));

            var user = _mapper.Map<User>(userUpdateDto);
            await _unitOfWork.UserRepository.UpdateAsync(user);

            var updatedUser = _mapper.Map<UserUpdateDto>(user);
            await _unitOfWork.SaveChanges();

            return updatedUser;
        }



        //Denna method letar efetr en user via inmatade email //Merran
        public async Task<UserDto> GetByEmail(string email)
        {
           
            var userExist = await _unitOfWork.UserRepository.FindAsync(u => u.Email == email);
            if (userExist != null) return _mapper.Map<UserDto>(userExist);
            else return null; //Return felmeddelande
        }

        //Denna method letar efetr en user via inmatade email och password //Merran
        public async Task<UserDto> GetByEmailAndPassword(string email, string password)
        {
            var userExist = await _unitOfWork.UserRepository.FindAsync(u => u.Email == email && u.Password == password);
            if (userExist != null) return _mapper.Map<UserDto>(userExist);
            else return null; //Return felmeddelande
            
        }

        public Task<UserUpdateDto> Update() //?? checka 
        {
            throw new NotImplementedException();
        }
    }
}
