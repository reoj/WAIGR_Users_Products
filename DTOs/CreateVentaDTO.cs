
using System.ComponentModel.DataAnnotations;

namespace WAIGR_Users_Products.DTOs
{
    public class CreateVentaDTO
    {
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