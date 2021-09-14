using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEmpleadoMedico:BEEmpleado
    {
        public override double Calcular_Salario()
        {
            return SalarioBase * 1.50 + Antiguedad;
        }
    }
}
