using Humanizer.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System;
using VeterinariaWebApp.ClientMvc.Models;
using VeterinariaWebApp.DataAccess.Migrations;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Implementaciones;
using VeterinariaWebApp.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private readonly ICitaRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IServicioRepository _servicioRepository;

        public CitasController(ICitaRepository repository, IClienteRepository clienteRepository, IMascotaRepository mascotaRepository, IServicioRepository servicioRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _mascotaRepository = mascotaRepository;
            _servicioRepository = servicioRepository;
        }

        public async Task<IActionResult> Index(string? nombre)
        {
            ViewBag.Nombre = nombre;
            return View(new CitaView()
            {
                Citas = await _repository.GetAllAsync(nombre)
            });
        }
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
           
            var entity = await _repository.FindByIdAsync(id);

            if (entity is null)
            {
                return RedirectToAction("Index", "Home");
            }

           
            var clienteId = entity.ClienteId ?? 0; 
            var mascotaId = entity.MascotaId ?? 0; 
            var servicioId = entity.ServicioId ?? 0;

            var cliente = await _clienteRepository.FindByIdAsync(clienteId);
            var mascota = await _mascotaRepository.FindByIdAsync(mascotaId);
            var servicio = await _servicioRepository.FindByIdAsync(servicioId);

            
            var model = new CitaInfo
            {
                Id = entity.Id,
                FechaHora = entity.FechaHora,
                Motivo = entity.Motivo,
                ClienteId = clienteId,
                Cliente = cliente != null ? cliente.Nombres + " " + cliente.Apellidos : string.Empty,
                MascotaId = mascotaId,
                FotoMascota = mascota != null ? mascota.UrlImagen : string.Empty,
                Mascota = mascota != null ? mascota.Nombres : string.Empty,
                ServicioId = servicioId,
                Servicio = servicio != null ? servicio.Nombres : string.Empty,
                PrecioUnitario = servicio != null ? servicio.PrecioUnitario : decimal.Zero
            };

            return View(model);
        }


        public async Task<IActionResult> Create()
        {
            var viewModel = new CitaViewModel
            {
                Clientes = await _clienteRepository.ListAsync(),
                Mascotas = await _mascotaRepository.ListAsync(),
                Servicios = await _servicioRepository.ListAsync()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create(CitaViewModel request)
        {
            await _repository.AddAsync(
                new Cita
                {
                    FechaHora = DateTime.Now,
                    Motivo = request.Motivo,
                    ClienteId = request.ClienteId,
                    MascotaId = request.MascotaId,
                    ServicioId = request.ServicioId
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

            var model = new CitaViewModel
            {
                FechaHora = entity.FechaHora,
                Motivo = entity.Motivo,
                ClienteId = entity.ClienteId ?? 0,
                Id = entity.Id,
                Clientes = await _clienteRepository.ListAsync(),
                MascotaId = entity.MascotaId ?? 0,
                Mascotas = await _mascotaRepository.ListAsync(),
                ServicioId = entity.ServicioId ?? 0,
                Servicios = await _servicioRepository.ListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(CitaViewModel request)
        {
            var cita = await _repository.FindByIdAsync(request.Id);

            if (cita is null)
            {
                ModelState.AddModelError("ID", "No se encontro el registro");
                return View();
            }

            cita.Motivo = request.Motivo;
            cita.ClienteId = request.ClienteId;
            cita.MascotaId = request.MascotaId;
            cita.ServicioId = request.ServicioId;

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
