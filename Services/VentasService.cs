using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public class VentasService : IVentasService
    {
        public DataContext SqlContext { get; }
        public VentasService(DataContext sqlContext)
        {
            this.SqlContext = sqlContext;
        }

        public async Task<Venta> GetVenta(Guid id)
        {
            var venta = await SqlContext.Ventas.FindAsync(id);
            if (venta == null)
            {
                throw new KeyNotFoundException("Venta not found");
            }
            return venta;
        }
        public async Task<List<Venta>> GetAllVentas()
        {
            return await SqlContext.Ventas.ToListAsync<Venta>();
        }
        public async Task<Venta> CreateVenta(Venta venta)
        {
            await SqlContext.Ventas.AddAsync(venta);
            await SqlContext.SaveChangesAsync();
            return venta;
        }
        public async Task<Venta> UpdateVenta(Venta venta)
        {
            SqlContext.Ventas.Update(venta);
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