using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class Mascota : EntityBase
    {

        [StringLength(50)]
        public string Nombres { get; set; } = default!;

        [StringLength(50)]
        public string? Raza { get; set; } = default!;

        [Column(TypeName = "date")] 
        public DateTime FechaNacimiento { get; set; }
        public Cliente? Cliente { get; set; }

        public int? ClienteId { get; set; }
        public TipoMascota? TipoMascota { get; set; }
        public int? TipoMascotaId { get; set; }
        public string? UrlImagen { get; set; }
    }
}
