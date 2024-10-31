using AutoMapper;
using WAIGR_Users_Products.Entities;
using WAIGR_Users_Products.DTOs;

namespace WAIGR_Users_Products.DTOs
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile ()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, CreateUserDTO>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, UpdateUserDTO>();
            CreateMap<CreateProductDTO, Producto>();
            CreateMap<Producto, CreateProductDTO>();
            CreateMap<UpdateProductDTO, Producto>();
            CreateMap<Producto, UpdateProductDTO>();
            CreateMap<CreateVentaDTO, Venta>();
            CreateMap<Venta, CreateVentaDTO>();
        }
    }

    
}