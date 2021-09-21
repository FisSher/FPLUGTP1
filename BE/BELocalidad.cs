namespace BE
{
    public class BELocalidad : Entidad
    {
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Codigo + " " + Nombre;
        }
    }
}