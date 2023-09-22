using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class TipoMascota : EntityBase
    {
        [StringLength(50)]
        public string Nombres { get; set; } = default!;
    }
}
