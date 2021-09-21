namespace BE
{
    public class BEEmpleadoIT : BEEmpleado
    {
        public string Lenguaje { get; set; }

        public override double Calcular_Salario()
        {
            Salario += 1.25 * Antiguedad;
            return Salario;
        }
    }
}