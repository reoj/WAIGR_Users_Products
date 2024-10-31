using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasAlternateKey(p => p.SKU);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Nombre);
        }
        public DbSet<Producto> Productos => Set<Producto>();

        public DbSet<Venta> Ventas => Set<Venta>();

        public DbSet<User> Users => Set<User>();

        
    }

}