using System;

namespace BE
{
    public class BEPuesto : Entidad
    {
        public String Nombre { get; set; }

        public override string ToString()
        {
            return Codigo + " " + Nombre;
        }

        public BEPuesto()
        {
        }

        //Constructor sobrecargado
        public BEPuesto(string _n)
        {
            Nombre = _n;
        }
    }
}