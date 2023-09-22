using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class MascotaView
    {
        public ICollection<MascotaInfo> Mascotas { get; set; } = new List<MascotaInfo>();
        public DeleteConfirmationModel Delete { get; set; } = new() { Controlador = "Mascotas" };
    }
}
