using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class MascotaInfo
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;

        public string? Raza { get; set; } = default!;

        public DateTime FechaNacimiento { get; set; }
        public int? ClienteId { get; set; }
        public string? Cliente { get; set; }

        public int? TipoMascotaId { get; set; }
        public string? TipoMascota { get; set; }
        public string? UrlImagen { get; set; }

    }
}
