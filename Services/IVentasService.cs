using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public interface IVentasService
    {
        Task<Venta> GetVenta(Guid id);
        Task<List<Venta>> GetAllVentas();
        Task<Venta> CreateVenta(Venta venta);
        Task<Venta> UpdateVenta(Venta venta);
        Task<Venta> DeleteVenta(Guid id);
    }
}