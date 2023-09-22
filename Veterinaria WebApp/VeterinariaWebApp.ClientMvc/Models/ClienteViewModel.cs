using System.ComponentModel.DataAnnotations;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = nameof(Nombres))]
        public string Nombres { get; set; } = default!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = nameof(Apellidos))]
        public string Apellidos { get; set; } = default!;

        [EmailAddress]
        public string Email { get; set; } = default!;

        [StringLength(50)]
        [Display(Name = nameof(Telefono))]
        public string Telefono { get; set; } = default!;

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-18);
        [StringLength(50)]
        [Display(Name = nameof(Direccion))]
        public string Direccion { get; set; } = default!;
    }
}
