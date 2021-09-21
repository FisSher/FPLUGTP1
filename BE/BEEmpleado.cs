using System;

namespace BE
{
    public abstract class BEEmpleado : Entidad
    {
        #region props

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int Puesto { get; set; }
        public double Salario { get; set; }
        public int Baja { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public int Antiguedad { get; set; }

        #endregion props

        #region metodos

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
            return Salario;
        }

        public override string ToString()
        {
            return Codigo + " " + Nombre + " " + Apellido;
        }

        #endregion metodos
    }
}