using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaWebApp.Entities.Config_Envio_correos_
{
    public class SmtpConfiguration
    {
        public string UserName { get; set; }
        public string Server { get; set; }
        public string Password { get; set; }
        public int PortNumber { get; set; }
        public string FromName { get; set; }
        public bool EnableSsl { get; set; }
    }
}
