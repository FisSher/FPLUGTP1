using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEmpleadoMedico : BEEmpleado
    {
        public override double Calcular_Salario()
        {
            Salario += 1.50 * Antiguedad;
            return Salario;
        }
    }
}
