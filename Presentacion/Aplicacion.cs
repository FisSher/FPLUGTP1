using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Aplicacion : Form
    {
        public Aplicacion()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados vEmpleados = new Empleados();
            vEmpleados.MdiParent = this;
            vEmpleados.Show();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Puesto vPuesto = new Puesto();
            vPuesto.MdiParent = this;
            vPuesto.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sucursal vSucusal = new Sucursal();
            vSucusal.MdiParent = this;
            vSucusal.Show();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localidad vLocalidad = new Localidad();
            vLocalidad.MdiParent = this;
            vLocalidad.Show();
        }
    }
}