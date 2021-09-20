using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEmpleadoIT : BEEmpleado
    {
        public string Lenguaje { get; set; }

        public override double Calcular_Salario()
        {
            return Salario * 1.25 + Antiguedad;
        }

    }
}
