using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class Cita : EntityBase
    {
        [Column(TypeName = "datetime")]
        [StringLength(50)]
        public DateTime FechaHora { get; set; } = default!;

        [StringLength(500)]
        public string Motivo { get; set; } = default!;
        public Cliente? Cliente { get; set; }

        public int? ClienteId { get; set; }
        public Mascota? Mascota { get; set; }

        public int? MascotaId { get; set; }
        public Servicio? Servicio { get; set; }

        public int? ServicioId { get; set; }
    }
}
