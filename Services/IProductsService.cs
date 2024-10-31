using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public interface IProductsService
    {
        Task<Producto> GetProduct(Guid id);
        Task<List<Producto>> GetAllProducts();
        Task<Producto> CreateProduct(Producto product);
        Task<Producto> UpdateProduct(Producto product);
        Task<Producto> DeleteProduct(Guid id);

    }
}