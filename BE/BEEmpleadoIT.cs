using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEmpleadoIT : BEEmpleado
    {

        public override double Calcular_Salario()
        {
            return SalarioBase * 1.25 + Antiguedad;
        }
    }
}
