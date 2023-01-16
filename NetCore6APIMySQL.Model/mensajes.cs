using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Model
{
    public class mensajes
    {
        public object mensaje;

        public int id { get; set; }
        public string correo { get; set; }
        public string remitente { get; set; }
        public string telefono { get; set; }
        public string asunto { get; set; }
        public string Mensaje { get; set; }
      

    }
}
