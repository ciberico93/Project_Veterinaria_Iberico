using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool Estado { get; set; }

        protected EntityBase()
        {
            Estado = true;
        }
    }
}
