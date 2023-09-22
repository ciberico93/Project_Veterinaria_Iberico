using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaWebApp.ClientMvc.Models;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Interfaces;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _repository;

        public ClientesController(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index(string? nombre)
        {
            ViewBag.Nombre = nombre;

            return View(new ClienteView()
            {
                Clientes = await _repository.GetAllAsync(nombre)
            });
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create(ClienteViewModel request)
        {
            await _repository.AddAsync(
                new Cliente
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    FechaNacimiento = request.FechaNacimiento,
                    Direccion = request.Direccion
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

            var model = new ClienteViewModel
            {
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Email = entity.Email,
                Telefono = entity.Telefono,
                FechaNacimiento = entity.FechaNacimiento,
                Direccion = entity.Direccion
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(ClienteViewModel request)
        {
            var cliente = await _repository.FindByIdAsync(request.Id);

            if (cliente is null)
            {
                ModelState.AddModelError("ID", "No se encontro el registro");
                return View();
            }

            cliente.Nombres = request.Nombres;
            cliente.Apellidos = request.Apellidos;
            cliente.Email = request.Email;
            cliente.Telefono = request.Telefono;
            cliente.FechaNacimiento = request.FechaNacimiento;
            cliente.Direccion = request.Direccion;

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
