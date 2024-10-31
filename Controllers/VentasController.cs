using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;
using WAIGR_Users_Products.Services;

namespace WAIGR_Users_Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        public IVentasService VentasService { get; }
        public VentasController(IVentasService ventasService)
        {
            this.VentasService = ventasService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVentas()
        {
            var ventas = await VentasService.GetAllVentas();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(Guid id)
        {
            var venta = await VentasService.GetVenta(id);
            return Ok(venta);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateVenta([FromBody] CreateVentaDTO venta)
        {
            var createdVenta = await VentasService.CreateVenta(venta);
            return createdVenta != null ? Ok(createdVenta) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta(Guid id, [FromBody] UpdateVentaDTO venta)
        {
            var updatedVenta = await VentasService.UpdateVenta(venta, id);
            return updatedVenta != null ? Ok(updatedVenta) : BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(Guid id)
        {
            var deletedVenta = await VentasService.DeleteVenta(id);
            return deletedVenta != null ? Ok(deletedVenta) : BadRequest();
        }
        
    }
}