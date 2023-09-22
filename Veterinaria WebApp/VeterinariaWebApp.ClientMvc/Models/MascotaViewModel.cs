using System.ComponentModel.DataAnnotations;
using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class MascotaViewModel
    {
        public ICollection<TipoMascota> TiposMascotas { get; set; } = new List<TipoMascota>();
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = nameof(Nombres))]
        public string Nombres { get; set; } = default!;

        public string? Raza { get; set; } = default!;
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-13);

        [Display(Name = "Nombre del Cliente")]
        public int? ClienteId { get; set; }
        [Display(Name = "Tipo de Mascota")]
        public int? TipoMascotaId { get; set; }
        public string? UrlImagen { get; set; }
        public IFormFile? Archivo { get; set; } = default!;

    }
}
