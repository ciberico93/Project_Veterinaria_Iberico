using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class ServicioView
    {
        public ICollection<ServicioInfo> Servicios { get; set; } = new List<ServicioInfo>();
        public DeleteConfirmationModel Delete { get; set; } = new() { Controlador = "Servicios" };
    }
}
