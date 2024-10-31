using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAIGR_Users_Products.DTOs
{
    public class UpdateVentaDTO
    {
        [Required]
        public Guid IDUsuario { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float Subtotal { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float IVA { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float Total { get; set; }
    }
}