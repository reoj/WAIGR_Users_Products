
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Controllers;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;
using BCrypt.Net;

namespace WAIGR_Users_Products.Services
{
    public class UsersService : IUsersService
    {
        public DataContext SqlContext;
        private readonly IMapper _mapper;
        public UsersService(DataContext sqlContext, IMapper mapper)
        {
            this.SqlContext = sqlContext;
            this._mapper = mapper;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await SqlContext.Users.FindAsync(id);
            return user is not null ? user : throw new KeyNotFoundException();

        }
        public async Task<List<User>> GetAllUsers()
        {
            var userList = await SqlContext.Users.ToListAsync();
            return userList is not null ? userList : throw new NullReferenceException();
        }

        public async Task<User> CreateUser(User user)
        {
            user.Contraseña = BCrypt.Net.BCrypt.HashPassword(user.Contraseña);
            var newUser = _mapper.Map<User>(user);
            await SqlContext.Users.AddAsync(newUser);
            await SqlContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUser(Guid id, User user)
        {
            var userToUpdate = await SqlContext.Users.FindAsync(id);
            if (userToUpdate is null)
            {
                throw new KeyNotFoundException();
            }
            user.Contraseña = BCrypt.Net.BCrypt.HashPassword(user.Contraseña);
            _mapper.Map(user, userToUpdate);
            SqlContext.Users.Update(userToUpdate);
            await SqlContext.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var userToDelete = await SqlContext.Users.FindAsync(id);
            if (userToDelete is null)
            {
                throw new KeyNotFoundException();
            }
            SqlContext.Users.Remove(userToDelete);
            await SqlContext.SaveChangesAsync();
            return true;
        }
    }
}