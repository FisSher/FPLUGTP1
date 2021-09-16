using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESucursal: Entidad
    {
        public List<BEEmpleado> ListaEmplados { get; set; }

        public BELocalidad Localidad { get; set; }

    }
}
