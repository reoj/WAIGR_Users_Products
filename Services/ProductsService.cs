using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;

namespace WAIGR_Users_Products.Services
{
    public class ProductsService: IProductsService
    {
        public DataContext SqlContext { get; }
        public IMapper Mapper { get; }

        public ProductsService(DataContext sqlContext, IMapper mapper)
        {
            this.SqlContext = sqlContext;
            this.Mapper = mapper;
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
        public async Task<Producto> CreateProduct(CreateProductDTO product)
        {
            Producto aAgregar = Mapper.Map<Producto>(product);
            aAgregar.IDproducto = Guid.NewGuid();
            await SqlContext.Productos.AddAsync(aAgregar);
            await SqlContext.SaveChangesAsync();
            return aAgregar;
        }
        public async Task<Producto> UpdateProduct(UpdateProductDTO product, Guid id)
        {
            var newData = Mapper.Map<Producto>(product);
            newData.IDproducto = id;
            var oldData = await SqlContext.Productos.FindAsync(id) ?? throw new KeyNotFoundException("Product not found");
            SqlContext.Entry(oldData).CurrentValues.SetValues(newData);
            await SqlContext.SaveChangesAsync();
            return newData;
        }
        public async Task<Producto> DeleteProduct(Guid id)
        {
            var product = await SqlContext.Productos.FindAsync(id) ?? throw new KeyNotFoundException("Product not found");
            SqlContext.Productos.Remove(product);
            await SqlContext.SaveChangesAsync();
            return product;
        }

    }
}