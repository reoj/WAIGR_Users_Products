using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public interface IVentasService
    {
        Task<Venta> GetVenta(Guid id);
        Task<List<Venta>> GetAllVentas();
        Task<Venta> CreateVenta(CreateVentaDTO venta);
        Task<Venta> UpdateVenta(UpdateVentaDTO venta, Guid id);
        Task<Venta> DeleteVenta(Guid id);
    }
}