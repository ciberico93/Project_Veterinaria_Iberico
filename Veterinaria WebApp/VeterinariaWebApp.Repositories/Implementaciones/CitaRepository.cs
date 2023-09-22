using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaWebApp.DataAccess.Data;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Interfaces;

namespace VeterinariaWebApp.Repositories.Implementaciones
{
    public class CitaRepository : RepositoryBase<Cita>, ICitaRepository
    {
        public CitaRepository(VeterinariaDbContext context) : base(context)
        {

        }

        public async Task<ICollection<CitaInfo>> GetAllAsync(string? filter)
        {
            var query = Context.Citas
                 .OrderBy(p => p.Motivo)
                 .AsQueryable();
            if (!string.IsNullOrEmpty(filter))
                query = query
                    .Where(p => p.Motivo.Contains(filter));

            return await query
                .Select(x => new CitaInfo()
                {
                    Id = x.Id,
                    FechaHora = x.FechaHora,
                    Motivo = x.Motivo,
                    ClienteId = x.ClienteId,
                    Cliente = x.Cliente != null ? x.Cliente.Nombres + " " + x.Cliente.Apellidos : string.Empty,
                    MascotaId = x.MascotaId,
                    FotoMascota = x.Mascota != null ? x.Mascota.UrlImagen : string.Empty,
                    Mascota = x.Mascota != null ? x.Mascota.Nombres : string.Empty,
                    ServicioId = x.ServicioId,
                    Servicio = x.Servicio != null ? x.Servicio.Nombres : string.Empty,
                    PrecioUnitario = x.Servicio != null ? x.Servicio.PrecioUnitario : decimal.Zero,
                })
                .ToListAsync();
        }
    }
}
