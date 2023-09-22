using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class TipoMascotaView
    {
        public ICollection<TipoMascotaInfo> TipoMascotas { get; set; } = new List<TipoMascotaInfo>();
        public DeleteConfirmationModel Delete { get; set; } = new() { Controlador = "TipoMascota" };
    }
}
