using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAIGR_Users_Products.Entities
{
    public class Producto
    {
        [Key]
        public Guid IDproducto { get; set; }
        [Required]
        public required string SKU { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        [Range(0, 10000)]
        public float Costo { get; set; }
        [Required]
        [Range(0, 10000)]
        public float PrecioVenta { get; set; }
        [Required]
        public required string ClaveSAT { get; set; }
        [Required]
        public required string ClaveKey { get; set; }

    }
}