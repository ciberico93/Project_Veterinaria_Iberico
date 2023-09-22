using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class ClienteInfo
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;


        public string Apellidos { get; set; } = default!;


        public string? Email { get; set; } = default!;

        public string? Telefono { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }

        public string? Direccion { get; set; } = default!;
    }
}
