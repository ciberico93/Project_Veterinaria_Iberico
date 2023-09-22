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
    public class ServicioRepository : RepositoryBase<Servicio>, IServicioRepository
    {
        public ServicioRepository(VeterinariaDbContext context) : base(context)
        {
            
        }

        public async Task<ICollection<ServicioInfo>> GetAllAsync(string? filter)
        {
            var query = Context.Servicios
            .OrderBy(p => p.Nombres)
            .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
                query = query
                    .Where(p => p.Nombres.Contains(filter));

            return await query
                .Select(x => new ServicioInfo()
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Descripcion = x.Descripcion,
                    PrecioUnitario = x.PrecioUnitario
                })
                .ToListAsync();
        }
    }
}
