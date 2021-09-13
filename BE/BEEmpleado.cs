using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEEmpleado:BEEntidad
    {
        #region props
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int Puesto { get; set; }
        public double SalarioBase { get; set; }
        public int Baja { get; set; }
        public List<BESucursal> SucursalesAsignadas { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public int Antiguedad { get; set; }
        #endregion



        //Voy a calcular algunos salarios correspondientes a la antiguedad
        public virtual int Calcular_antiguedad()
        {
            Antiguedad = DateTime.Now.Year - FechaIngreso.Year;
            if (DateTime.Now.Month < FechaIngreso.Month)
                Antiguedad -= 1;
            if (DateTime.Now.Month == FechaIngreso.Month && DateTime.Now.Day < FechaIngreso.Day)
                Antiguedad -= 1;

            return Antiguedad;
        }
        
        public virtual double Calcular_Salario()
        {
            return SalarioBase;
        }

    }
}
