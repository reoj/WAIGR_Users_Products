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
        public string SKU { get; set; } 
        [Required] 
        public string Nombre { get; set; }
        [Required]
        public float Costo { get; set; }
        [Required]
        public float PrecioVenta { get; set; }
        [Required]
        public string ClaveSAT { get; set; }
        [Required]
        public string ClaveKey { get; set; }

    }
}