using AutoMapper;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.DTOs
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile ()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, CreateUserDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<GetUserDTO, User>();
        }
    }

    
}