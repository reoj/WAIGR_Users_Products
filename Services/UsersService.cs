
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Controllers;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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

        public async Task<User> CreateUser(CreateUserDTO user)
        {
            Guid newUserGuid = Guid.NewGuid();
            user.Contraseña = BCrypt.Net.BCrypt.HashPassword(user.Contraseña);
            var newUser = _mapper.Map<User>(user);
            newUser.IdUsuario = newUserGuid;
            await SqlContext.Users.AddAsync(newUser);
            await SqlContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUser(Guid id, UpdateUserDTO user)
        {
            var userToUpdate = await SqlContext.Users.FindAsync(id) ?? throw new KeyNotFoundException();
            user.Contraseña = BCrypt.Net.BCrypt.HashPassword(user.Contraseña);
            _mapper.Map(user, userToUpdate);
            userToUpdate.IdUsuario = id;
            SqlContext.Users.Update(userToUpdate);
            await SqlContext.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var userToDelete = await SqlContext.Users.FindAsync(id) ?? throw new KeyNotFoundException();
            SqlContext.Users.Remove(userToDelete);
            await SqlContext.SaveChangesAsync();
            return true;
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_secret_key_here"); // Use the same key as in Program.cs
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.IdUsuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "your_issuer",
                Audience = "your_audience",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<string> Authenticate(string username, string password)
        {
            var user = await SqlContext.Users.SingleOrDefaultAsync(u => u.Nombre == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Contraseña))
            {
                throw new UnauthorizedAccessException("Username or password is incorrect");
            }

            return GenerateJwtToken(user);
        }
    }
}