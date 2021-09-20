using System.Collections.Generic;

namespace BE
{
    public class BESucursal : Entidad
    {
        public List<BEEmpleado> ListaEmplados { get; set; }

        public BELocalidad Localidad { get; set; }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return Codigo + " " + Nombre + " " + Localidad.Nombre;
        }
    }
}