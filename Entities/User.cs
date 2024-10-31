using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WAIGR_Users_Products.Entities
{
    public class User
    {
        [Key]
        public Guid IdUsuario { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        [MaxLength(50)]
        public string Usuario { get; set; }
    }
}