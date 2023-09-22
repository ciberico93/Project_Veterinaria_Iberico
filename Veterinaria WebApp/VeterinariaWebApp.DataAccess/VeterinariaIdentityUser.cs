using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.DataAccess
{
    public class VeterinariaIdentityUser : IdentityUser
    {
        [StringLength(50)]
        public string Nombres { get; set; } = default!;

        [StringLength(50)]
        public string Apellidos { get; set; } = default!;
    }
}
