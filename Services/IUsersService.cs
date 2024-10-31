
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{

    public interface IUsersService
    {
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(Guid id, User user);
        Task<bool> DeleteUser(Guid id);


    }
}