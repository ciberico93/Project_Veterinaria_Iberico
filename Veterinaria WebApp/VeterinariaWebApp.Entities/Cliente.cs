using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class Cliente : EntityBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Nombres { get; set; } = default!;

        [StringLength(50, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string Apellidos { get; set; } = default!;

        [StringLength(200)]
        public string? Email { get; set; } = default!;
        [StringLength(50)]
        public string? Telefono { get; set; } = default!;

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [StringLength(200)]
        public string? Direccion { get; set; } = default!;


    }
}
