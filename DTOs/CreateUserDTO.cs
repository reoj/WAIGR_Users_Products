using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAIGR_Users_Products.DTOs
{
    public class CreateUserDTO
    {
        public required string Nombre { get; set; }
        public required string Contraseña { get; set; }
        public required string Usuario { get; set; }

    }
}