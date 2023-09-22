using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaWebApp.ClientMvc.Models;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Interfaces;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    [Authorize(Roles = Constantes.RolAdmin)]
    public class ServiciosController : Controller
    {
        private readonly IServicioRepository _repository;

        public ServiciosController(IServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string? nombre)
        {
            ViewBag.nombre = nombre;
            return View(new ServicioView()
            {
                Servicios = await _repository.GetAllAsync(nombre)
            });
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create(ServicioViewModel request)
        {
            await _repository.AddAsync(
               new Servicio
               {
                   Nombres = request.Nombres,
                   Descripcion = request.Descripcion,
                   PrecioUnitario = request.PrecioUnitario
               });

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new ServicioViewModel
            {
                Nombres = entity.Nombres,
                Descripcion = entity.Descripcion,
                PrecioUnitario = entity.PrecioUnitario,
                Id = entity.Id

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(ServicioViewModel request)
        {
            var servicio = await _repository.FindByIdAsync(request.Id);

            if (servicio is null)
            {
                ModelState.AddModelError("ID", "No se encontro el registro");
                return View();
            }

            servicio.Nombres = request.Nombres;
            servicio.Descripcion = request.Descripcion;
            servicio.PrecioUnitario = request.PrecioUnitario;

            await _repository.UpdateAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
