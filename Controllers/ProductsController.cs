
using Microsoft.AspNetCore.Mvc;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;
using WAIGR_Users_Products.Services;

namespace WAIGR_Users_Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductsService ProductsService { get; }
        public ProductsController(IProductsService productsService)
        {
            this.ProductsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await ProductsService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await ProductsService.GetProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO product)
        {
            var createdProduct = await ProductsService.CreateProduct(product);
            return createdProduct != null ? Ok(createdProduct) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDTO product)
        {

            var updatedProduct = await ProductsService.UpdateProduct(product, id);
            return updatedProduct != null ? Ok(updatedProduct) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deletedProduct = await ProductsService.DeleteProduct(id);
            return deletedProduct != null ? Ok(deletedProduct) : BadRequest();
        }
    }
}