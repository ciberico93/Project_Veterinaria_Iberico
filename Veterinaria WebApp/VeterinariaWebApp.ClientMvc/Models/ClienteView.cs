using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.ClientMvc.Models
{
    public class ClienteView
    {
        public ICollection<ClienteInfo> Clientes { get; set; } = new List<ClienteInfo>();
        public DeleteConfirmationModel Delete { get; set; } = new() { Controlador = "Clientes" };
    }
}
