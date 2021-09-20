using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPuesto : Entidad
    {
        public String Nombre { get; set; }

        public override string ToString()
        {
            return Codigo + " " + Nombre;
        }
        
        public BEPuesto() { }

        //Constructor sobrecargado
        public BEPuesto(string _n)
        {
            Nombre = _n;
        }

    }
}
