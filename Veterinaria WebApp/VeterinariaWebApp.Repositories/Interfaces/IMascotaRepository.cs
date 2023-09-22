using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.Repositories.Interfaces
{
    public interface IMascotaRepository : IRepositoryBase<Mascota>
    {
        Task<ICollection<MascotaInfo>> GetAllAsync(string? filter);
    }
}
