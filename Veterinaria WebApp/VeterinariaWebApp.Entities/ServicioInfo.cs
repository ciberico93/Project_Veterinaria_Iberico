using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class ServicioInfo
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;

        public string? Descripcion { get; set; } = default!;

        public decimal PrecioUnitario { get; set; }
    }
}
