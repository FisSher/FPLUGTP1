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