using Microsoft.AspNetCore.Mvc;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
