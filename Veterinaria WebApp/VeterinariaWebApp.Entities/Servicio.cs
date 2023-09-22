using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class Servicio : EntityBase
    {
        [StringLength(50)]
        public string Nombres { get; set; } = default!;

        [StringLength(500)]
        public string? Descripcion { get; set; } = default!;

        public decimal PrecioUnitario { get; set; }


    }
}
