using System.ComponentModel.DataAnnotations;

namespace WAIGR_Users_Products.Entities
{
    public class Venta
    {
        [Key]
        public Guid IDVenta { get; set; }
        [Required]
        public Guid IDUsuario { get; set; }
        public User Usuario { get; set; }
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