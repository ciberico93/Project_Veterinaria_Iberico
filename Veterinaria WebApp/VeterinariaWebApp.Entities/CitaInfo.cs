using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class CitaInfo
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; } = default!;

        public string Motivo { get; set; } = default!;
        public int? ClienteId { get; set; }
        public string? Cliente { get; set; }

        public int? MascotaId { get; set; }
        public string? Mascota { get; set; }
        public int? ServicioId { get; set; }

        public string? Servicio { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public string? FotoMascota { get; set; }

        
    }
}
