using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WAIGR_Users_Products.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        public required string SKU { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        [Range(0, 10000), DataType(DataType.Currency)]
        public float Costo { get; set; }
        [Required]
        [Range(0, 10000), DataType(DataType.Currency)]
        public float PrecioVenta { get; set; }
        [Required]
        public required string ClaveSAT { get; set; }
        [Required]
        public required string ClaveKey { get; set; }
    }
}