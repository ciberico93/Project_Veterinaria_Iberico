using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VeterinariaWebApp.ClientMvc.Models;
using VeterinariaWebApp.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICitaRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IServicioRepository _servicioRepository;

        public HomeController(ILogger<HomeController> logger, ICitaRepository repository, IClienteRepository clienteRepository, IMascotaRepository mascotaRepository, IServicioRepository servicioRepository)
        {
            _logger = logger;
            _repository = repository;
            _clienteRepository = clienteRepository;
            _mascotaRepository = mascotaRepository;
            _servicioRepository = servicioRepository;
        }

        public async Task<IActionResult> Index(string? buscar)
        {
            ViewBag.Nombre = buscar;
            return View(new CitaView()
            {
                Citas = await _repository.GetAllAsync(buscar)
            });
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}