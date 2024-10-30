using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WAIGR_Users_Products.Entities
{
    public class Venta
    {
        [Key]
        public Guid IDVenta { get; set; }
        [Required]
        public Guid IDUsuario { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        public float Subtotal { get; set; }
        [Required]
        public float IVA { get; set; }
        [Required]
        public float Total { get; set; }
    }
}