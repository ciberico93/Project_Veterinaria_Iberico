using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VeterinariaWebApp.DataAccess.Data;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Repositories.Interfaces;

namespace VeterinariaWebApp.Repositories.Implementaciones
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly VeterinariaDbContext Context;
        protected RepositoryBase(VeterinariaDbContext context)
        {
            Context = context;
        }

        public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            var query = Context.Set<TEntity>()
                .AsQueryable();

            if (predicate is not null)
                query = query.Where(predicate);

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TInfo>> ListAsync<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null)
        {
            var query = Context.Set<TEntity>()
                .Where(predicate)
                .AsQueryable();

            // SELECT de Clientes, "TipoCliente"
            // SELECT de Producto, "Categoria, Marca"

            if (!string.IsNullOrWhiteSpace(relationships))
            {
                foreach (var tabla in relationships.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(tabla);
                }
            }

            return await query
                .Select(selector)
                .ToListAsync();
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity != null)
            {
                entity.Estado = false;
                await UpdateAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con el id {id}");
            }
        }
    }
}
