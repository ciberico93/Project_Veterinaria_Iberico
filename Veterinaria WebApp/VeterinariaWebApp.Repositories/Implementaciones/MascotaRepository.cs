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
    public class MascotaRepository : RepositoryBase<Mascota>,IMascotaRepository
    {
        public MascotaRepository(VeterinariaDbContext context) : base(context)
        {
            
        }

        public async Task<ICollection<MascotaInfo>> GetAllAsync(string? filter)
        {
            var query = Context.Mascotas
                 .OrderBy(p => p.Nombres)
                 .AsQueryable();
            if (!string.IsNullOrEmpty(filter))
                query = query
                    .Where(p => p.Nombres.Contains(filter));

            return await query
                .Select(x => new MascotaInfo()
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Raza = x.Raza,
                    FechaNacimiento = x.FechaNacimiento,
                    TipoMascotaId = x.TipoMascotaId,
                    TipoMascota = x.TipoMascota != null ? x.TipoMascota.Nombres : string.Empty,
                    ClienteId = x.ClienteId,
                    Cliente = x.Cliente != null ? x.Cliente.Nombres+" "+x.Cliente.Apellidos : string.Empty,
                    UrlImagen = x.UrlImagen
                })
                .ToListAsync();
        }
    }
}
