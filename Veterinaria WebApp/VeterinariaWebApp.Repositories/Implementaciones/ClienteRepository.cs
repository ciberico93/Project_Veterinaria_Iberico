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
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(VeterinariaDbContext context) : base(context)
        {
            
        }

        public async Task<ICollection<ClienteInfo>> GetAllAsync(string? filter)
        {
            var query = Context.Clientes
                 .OrderBy(p => p.Nombres)
                 .AsQueryable();

            if(!string.IsNullOrEmpty(filter))
                query = query
                    .Where(p => p.Nombres.Contains(filter));

            return await query
                .Select(x => new ClienteInfo()
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    FechaNacimiento = x.FechaNacimiento,
                    Email = x.Email,
                    Telefono = x.Telefono,
                    Direccion = x.Direccion
                })
                .ToListAsync();
        }
    }
}
