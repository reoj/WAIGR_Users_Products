using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Context
{
    public interface IDataContext
    {
        DbSet<Producto> Productos { get; }
        DbSet<Venta> Ventas { get; }
        DbSet<User> Users { get; }
    }
}
