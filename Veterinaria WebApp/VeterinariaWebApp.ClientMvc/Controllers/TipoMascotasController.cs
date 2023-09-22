using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaWebApp.ClientMvc.Models;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Interfaces;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    [Authorize(Roles = Constantes.RolAdmin)]
    public class TipoMascotasController : Controller
    {
        private readonly ITipoMascotaRepository _repository;

        public TipoMascotasController(ITipoMascotaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string? nombre)
        {
            ViewBag.Nombre = nombre;

            return View(new TipoMascotaView()
            {
                TipoMascotas = await _repository.GetAllAsync(nombre)
            });
        }
        [Authorize(Roles = Constantes.RolAdmin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create(TipoMascotaViewModel request)
        {
            await _repository.AddAsync(
                new TipoMascota
                {
                    Nombres = request.Nombres
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

            var model = new TipoMascotaViewModel
            {
                Nombres = entity.Nombres,
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(TipoMascotaViewModel request)
        {
            var cliente = await _repository.FindByIdAsync(request.Id);

            if (cliente is null)
            {
                ModelState.AddModelError("ID", "No se encontro el registro");
                return View();
            }

            cliente.Nombres = request.Nombres;

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
