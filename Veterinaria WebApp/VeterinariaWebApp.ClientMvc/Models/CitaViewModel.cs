using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class CitaViewModel
    {
        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

        public int Id { get; set; }
        [Display(Name = "Fecha y hora")]
        public DateTime FechaHora { get; set; } = default!;
        [StringLength(500)]
        public string Motivo { get; set; } = default!;
        [Display(Name = "Nombre del cliente")]
        public int? ClienteId { get; set; }
        [Display(Name = "Nombre de la mascota")]
        public int? MascotaId { get; set; }
        [Display(Name = "Nombre del servicio")]

        public int? ServicioId { get; set; }
        public IFormFile Archivo { get; set; } = default!;
        public string? UrlImagen { get; set; }
    }
}
