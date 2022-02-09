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

        public async Task<Guid> CreateUser(UserCreateDto newUser)
        {   
           
           var user = _mapper.Map<User>(newUser);

           var users = await _unitOfWork.UserRepository.GetAllAsync();
           
           var item = users.FirstOrDefault(x => x.Email == user.Email);


            if (item == null)

            {

                user.Password = Cryptography.EncryptData(newUser.Password);

                user = await _unitOfWork.UserRepository.AddAsync(user);


                await _unitOfWork.SaveChanges();

                return user.Id;
            }
            else
            {
                throw new Exception("User with the email already exists");
            }


        }
    

        public async Task<bool> DeleteUser(Guid id)
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

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            if(users != null)
            {
                var mappedUsers = _mapper.Map<List<UserDto>>(users);
                return mappedUsers;
            }
            return null; 
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByGuidAsync(id);
       
            if (user != null)
            {
                var mappedUsers = _mapper.Map<UserDto>(user);
                return mappedUsers;

            }

            return null;
        }

        public async Task<bool> UpdateUser(UserUpdateDto userUpdateDto)
        {   
            if (userUpdateDto == null) throw new ArgumentNullException(nameof(userUpdateDto));

            var user = _mapper.Map<User>(userUpdateDto);
            await _unitOfWork.UserRepository.UpdateAsync(user);

            var updatedUser = _mapper.Map<UserUpdateDto>(user);
            await _unitOfWork.SaveChanges();

            return true;

            //------------------- testa denna metod
        }

        public Task<UserDto> GetList()
        {
            throw new NotImplementedException();
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
        public async Task<Guid> Login(UserLoginDto userLogin)
        {

            
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var user = users.FirstOrDefault(database => database.Email == userLogin.Email && database.Password == Cryptography.EncryptData(userLogin.Password));
           

            if (user == null)
            {
                return Guid.Empty;
            }

            return user.Id;
        }

      
    }
}
