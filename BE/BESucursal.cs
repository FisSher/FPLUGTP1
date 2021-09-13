using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESucursal: BEEntidad
    {
        public List<BEEmpleado> ListaEmplados { get; set; }
        public List<BEPuesto> ListaPuestos { get; set; }

    }
}
