
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public class VentasService : IVentasService
    {
        public DataContext SqlContext { get; }

        private IMapper mapper;
        private IUsersService usersService;

        public VentasService(DataContext sqlContext, IMapper mapper, IUsersService usersService)
        {
            this.SqlContext = sqlContext;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task<Venta> GetVenta(Guid id)
        {
            var venta = await SqlContext.Ventas.Include(one => one.Usuario).FirstOrDefaultAsync(one => one.IDVenta == id) ?? throw new KeyNotFoundException("Venta not found");
            return venta;
        }
        public async Task<List<Venta>> GetAllVentas()
        {
            return await SqlContext.Ventas.Include(one => one.Usuario).ToListAsync<Venta>();
        }
        public async Task<Venta> CreateVenta(CreateVentaDTO venta)
        {
            var nuevaVenta = mapper.Map<Venta>(venta);
            nuevaVenta.IDVenta = Guid.NewGuid();
            nuevaVenta.Usuario = await usersService.GetUserById(venta.IDUsuario);
            await SqlContext.Ventas.AddAsync(nuevaVenta);
            await SqlContext.SaveChangesAsync();
            return nuevaVenta;
        }
        public async Task<Venta> UpdateVenta(Venta venta)
        {
            SqlContext.Ventas.Update(venta);
            venta.Usuario = await usersService.GetUserById(venta.IDUsuario);
            await SqlContext.SaveChangesAsync();
            return venta;
        }
        public async Task<Venta> DeleteVenta(Guid id)
        {
            var venta = await SqlContext.Ventas.FindAsync(id);
            if (venta == null)
            {
                throw new KeyNotFoundException("Venta not found");
            }
            SqlContext.Ventas.Remove(venta);
            await SqlContext.SaveChangesAsync();
            return venta;
        }
    }
}