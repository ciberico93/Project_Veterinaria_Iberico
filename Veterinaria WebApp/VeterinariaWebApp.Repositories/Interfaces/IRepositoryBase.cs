using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Listar objetos basados en el EntityBase
        /// </summary>
        Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? precidade = null);
        /// <summary>
        /// Lista de objetos del EntityBase con un selector
        /// </summary>
        Task<ICollection<TInfo>> ListAsync<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null);

        /// <summary>
        /// Crear un registro
        /// </summary>
        Task<int> AddAsync(TEntity entity);

        /// <summary>
        /// Buscar un registro por ID
        /// </summary>
        Task<TEntity?> FindByIdAsync(int id);

        /// <summary>
        /// Actualizar cambios en la BD
        /// </summary>
        Task UpdateAsync();

        /// <summary>
        /// Eliminar un registro de la BD
        /// </summary>
        Task DeleteAsync(int id);
    }
}
