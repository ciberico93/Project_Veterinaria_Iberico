using Azure.Core;
using VeterinariaWebApp.ClientMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using VeterinariaWebApp.ClientMvc.Models;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VeterinariaWebApp.ClientMvc.Controllers
{
    [Authorize]
    public class MascotasController : Controller
    {
        private readonly IMascotaRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoMascotaRepository _tipoMascota;
        private readonly IFileUploader _fileUploader;

        public MascotasController(IMascotaRepository repository, IClienteRepository clienteRepository, ITipoMascotaRepository tipoMascota, IFileUploader fileUploader)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _tipoMascota = tipoMascota;
            _fileUploader = fileUploader;
        }

        public async Task<IActionResult> Index(string? nombre)
        {
            ViewBag.Nombre = nombre;
            return View(new MascotaView()
            {
                Mascotas = await _repository.GetAllAsync(nombre)
                
            });
        }
       

        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create()
        {
            var viewModel = new MascotaViewModel
            {
                TiposMascotas = await _tipoMascota.ListAsync(),
                Clientes = await _clienteRepository.ListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Create(MascotaViewModel request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new Mascota
                    {
                        Nombres = request.Nombres,
                        Raza = request.Raza,
                        FechaNacimiento = request.FechaNacimiento,
                        ClienteId = request.ClienteId,
                        TipoMascotaId = request.TipoMascotaId,
                        UrlImagen = request.UrlImagen
                    };

                    // Procesa la carga de la imagen si existe
                    var file = HttpContext.Request.Form.Files.FirstOrDefault();
                    if (file is not null)
                    {
                        var tupla = await _fileUploader.UploadFileAsync(file);
                        if (!string.IsNullOrEmpty(tupla.MensajeError))
                        {
                            ModelState.AddModelError("Archivo", tupla.MensajeError);
                            return View(request);
                        }
                        entity.UrlImagen = tupla.Url;
                    }
                    else
                    {
                        entity.UrlImagen = null;
                    }

                    await _repository.AddAsync(entity);

                    return RedirectToAction(nameof(Index));
                }

                // Si ModelState no es válido, vuelve a mostrar la vista con los errores
                return View(request);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(request);
            }
        }

        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new MascotaViewModel
            {
                Nombres = entity.Nombres,
                Raza = entity.Raza,
                FechaNacimiento = entity.FechaNacimiento,
                ClienteId = entity.ClienteId ?? 0,
                Clientes = await _clienteRepository.ListAsync(),
                Id = entity.Id,
                TipoMascotaId = entity.TipoMascotaId ?? 0,
                TiposMascotas = await _tipoMascota.ListAsync(),
                UrlImagen = entity.UrlImagen
                
                
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> Edit(MascotaViewModel request)
        {
                var cita = await _repository.FindByIdAsync(request.Id);

                if (cita is null)
                {
                    ModelState.AddModelError("ID", "No se encontro el registro");
                    return View();
                }

                cita.Nombres = request.Nombres;
                cita.Raza = request.Raza;
                cita.FechaNacimiento = request.FechaNacimiento;
                cita.ClienteId = request.ClienteId;
                cita.TipoMascotaId = request.TipoMascotaId;

                var imageFile = HttpContext.Request.Form.Files.FirstOrDefault();
                if (imageFile is not null)
                {
                    var tupla = await _fileUploader.UploadFileAsync(imageFile);
                    if (!string.IsNullOrEmpty(tupla.MensajeError))
                    {
                        ModelState.AddModelError("imageFile", tupla.MensajeError);
                        return View();
                    }
                    cita.UrlImagen = tupla.Url;
                }

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
