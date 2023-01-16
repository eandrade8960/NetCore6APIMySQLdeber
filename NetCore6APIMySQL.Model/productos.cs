using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Model
{
    public class productos
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int foto { get; set; }
    }
}
