
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Controllers;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

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

        public async Task<ServiceResponse<User>> CreateUser(CreateUserDTO nwUser)
        {
            return await ServiceHelper<User>.HandleAnActionInsideAServiceResponse(CreateUserFromDTO, nwUser);
        }
        public async Task<ServiceResponse<GetUserDTO>> GetUser(Guid id)
        {
            return await ServiceHelper<GetUserDTO>.HandleAnActionInsideAServiceResponse(ReadyUserForExport, id);
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            return await ServiceHelper<List<GetUserDTO>>.HandleAnActionInsideAServiceResponse(() => GenerateReadableListOfUsers());
        }


        public Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO nwUser)
        {
            throw new NotImplementedException();
        }


        public async Task<User> GetUserFromDataRepo(Guid idetifier)
        {
            var requested = await SqlContext.Users.FindAsync(idetifier);
            return ServiceHelper<User>.NoNullsAccepted(requested);
        }
        private async Task<GetUserDTO> ReadyUserForExport(object arg)
        {
            // Retrieve
            var id = (Guid)arg;
            var requested = await GetUserFromDataRepo(id);

            // act: Generate the new User object 
            GetUserDTO inCreation = new()
            {
                Nombre = requested.Nombre,
                Usuario = requested.Usuario
            };

            // Return
            return inCreation;
        }
        private async Task<User> CreateUserFromDTO(object obj)
        {
            // Retrieve
            var creationInformation = (CreateUserDTO)obj;

            // act: Generate the new User object 
            User inCreation = new()
            {
                Nombre = creationInformation.Nombre,
                Contraseña = creationInformation.Contraseña,
                Usuario = creationInformation.Usuario
            };
            var added = await SqlContext.Users.AddAsync(inCreation);

            // Save in Repository 
            _ = await SqlContext.SaveChangesAsync();

            // Return
            return ServiceHelper<User>.NoNullsAccepted(added.Entity);
        }
        private async Task<List<GetUserDTO>> GenerateReadableListOfUsers()
        {
            List<User> listOfUsers = await GetListOfAllUsersFromDataRepository();
            List<GetUserDTO> listofUserDTOs = GenerateListofUserDTOFromUsers(listOfUsers);
            return listofUserDTOs;
        }
        private List<GetUserDTO> GenerateListofUserDTOFromUsers(List<User> listOfUsers)
        {
            var listofUserDTOs = new List<GetUserDTO>();

            listOfUsers.ForEach(currentUser => listofUserDTOs
                .Add(_mapper.Map<GetUserDTO>(currentUser)));
            return listofUserDTOs;
        }

        private async Task<List<User>> GetListOfAllUsersFromDataRepository()
        {
            return await SqlContext.Users.ToListAsync<User>();
        }


        private async Task<User> GetUserFromDataRepo(object arg)
        {
            var requested = await SqlContext.Users.FindAsync(arg);
            return ServiceHelper<User>.NoNullsAccepted(requested);
        }

        public Task<ServiceResponse<GetUserDTO>> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}