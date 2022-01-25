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

        public Task<UserCreateDto> Create(UserCreateDto newUser)
        {
      
            throw new NotImplementedException();
        
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<UserUpdateDto> Update()
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

        public IEnumerable<ClaimsIdentity> Authenticate(string email)
        {
            throw new NotImplementedException();
        }

        //public void Add(User user)
        //{
        //    _db.Users.Add(user);
        //    _db.SaveChanges();
        //}
    }
}
