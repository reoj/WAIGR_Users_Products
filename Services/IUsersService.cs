
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{

    public interface IUsersService
    {
        Task<ServiceResponse<User>> CreateUser(CreateUserDTO nwUser);
        Task<ServiceResponse<GetUserDTO>> GetUser(Guid id);
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();
        Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO nwUser);
        Task<ServiceResponse<GetUserDTO>> DeleteUser(Guid id);
        Task<User> GetUserFromDataRepo(Guid idn);
    }
}