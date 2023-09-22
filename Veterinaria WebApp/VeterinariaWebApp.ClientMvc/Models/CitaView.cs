using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class CitaView
    {
        public ICollection<CitaInfo> Citas { get; set; } = new List<CitaInfo>();
        public DeleteConfirmationModel Delete { get; set; } = new() { Controlador = "Citas" };
    }
}
