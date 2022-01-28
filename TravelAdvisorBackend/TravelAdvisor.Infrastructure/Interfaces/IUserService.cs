using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IUserService
    {

        Task<UserDto> GetUser(Guid id);

        Task<bool> DeleteUser(Guid id);

        Task<Guid> CreateUser(UserCreateDto newUser);

        Task<bool> UpdateUser(UserUpdateDto userUpdate);

        Task<List<UserDto>> GetAllUsers();

        Task<UserDto> GetList();

        Task<bool> Login(UserLoginDto userLogin);


    }
}
