using System.ComponentModel.DataAnnotations;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = nameof(Nombres))]
        public string Nombres { get; set; } = default!;

        [StringLength(500)]
        [Display(Name = nameof(Descripcion))]
        public string? Descripcion { get; set; } = default!;
        [Display(Name = nameof(PrecioUnitario))]
        public decimal PrecioUnitario { get; set; }

    }
}
