using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public interface IProductsService
    {
        Task<Producto> GetProduct(Guid id);
        Task<List<Producto>> GetAllProducts();
        Task<Producto> CreateProduct(CreateProductDTO product);
        Task<Producto> UpdateProduct(UpdateProductDTO product, Guid id);
        Task<Producto> DeleteProduct(Guid id);

    }
}