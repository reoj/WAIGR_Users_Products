using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public class ProductsService: IProductsService
    {
        public DataContext SqlContext { get; }
        public ProductsService(DataContext sqlContext)
        {
            this.SqlContext = sqlContext;
        }

        public async Task<Producto> GetProduct(Guid id)
        {
            var product = await SqlContext.Productos.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return product;
        }
        public async Task<List<Producto>> GetAllProducts()
        {
            return await SqlContext.Productos.ToListAsync<Producto>();
        }
        public async Task<Producto> CreateProduct(Producto product)
        {
            await SqlContext.Productos.AddAsync(product);
            await SqlContext.SaveChangesAsync();
            return product;
        }
        public async Task<Producto> UpdateProduct(Producto product)
        {
            SqlContext.Productos.Update(product);
            await SqlContext.SaveChangesAsync();
            return product;
        }
        public async Task<Producto> DeleteProduct(Guid id)
        {
            var product = await SqlContext.Productos.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            SqlContext.Productos.Remove(product);
            await SqlContext.SaveChangesAsync();
            return product;
        }

    }
}