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
    public class TipoMascotaRepository : RepositoryBase<TipoMascota>, ITipoMascotaRepository
    {
        public TipoMascotaRepository(VeterinariaDbContext context) : base(context)
        {
            
        }

        public async Task<ICollection<TipoMascotaInfo>> GetAllAsync(string? filter)
        {
            var query = Context.TipoMascotas
            .OrderBy(p => p.Nombres)
            .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
                query = query
                    .Where(p => p.Nombres.Contains(filter));

            return await query
                .Select(x => new TipoMascotaInfo()
                {
                    Id = x.Id,
                    Nombres = x.Nombres
                })
                .ToListAsync();
        }
    }
}
