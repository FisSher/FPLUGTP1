using BE;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Sucursal : Form
    {
        public Sucursal()
        {
            InitializeComponent();
            oBESucursal = new BESucursal();
            oBLLSucursal = new BLLSucursal();
            oBLLLocalidad = new BLLLocalidad();
        }

        private BESucursal oBESucursal;
        private BLLSucursal oBLLSucursal;
        private BLLLocalidad oBLLLocalidad;

        private void ListarTodo()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = oBLLSucursal.ListarTodo();
            if (oBLLSucursal.ListarTodo().Count > 0)
            {
                label4.Text = oBLLSucursal.ListarTodo().Count.ToString();
            }
            else
            {
                label4.Text = "0";
            }
        }

        private void ListarEmpleados(BESucursal sucursal)
        {
            if (sucursal is null)
            {
            }
            else
            {
                if (sucursal.ListaEmplados != null)
                {
                    listBox2.DataSource = sucursal.ListaEmplados;
                }
            }
        }

        private void Sucursal_Load(object sender, EventArgs e)
        {
            ListarTodo();
            comboBox1.DataSource = oBLLLocalidad.ListarTodo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                oBESucursal = new BESucursal();
                oBESucursal.Nombre = textBox1.Text;
                oBESucursal.Localidad = (BELocalidad)comboBox1.SelectedItem;
                oBESucursal.ListaEmplados = new List<BEEmpleado>();
                oBLLSucursal.Guardar(oBESucursal);
                ListarTodo();
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                oBESucursal = (BESucursal)listBox1.SelectedItem;
                oBESucursal.Nombre = textBox1.Text;
                oBESucursal.Localidad = (BELocalidad)comboBox1.SelectedItem;
                oBLLSucursal.Guardar(oBESucursal);
                ListarTodo();
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                oBESucursal = (BESucursal)listBox1.SelectedItem;
                oBLLSucursal.Baja(oBESucursal);
                ListarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonQuitaEmpleado_Click(object sender, EventArgs e)
        {
            BEEmpleado empleado = (BEEmpleado)listBox2.SelectedItem;
            BESucursal oBESucursal = (BESucursal)listBox1.SelectedItem;
            if (oBLLSucursal.Quitar_Sucursal_Empleado(oBESucursal, empleado))
            {
                MessageBox.Show("Eliminado");
                ListarEmpleados(oBESucursal);
                ListarTodo();
            }
            else
            {
                MessageBox.Show("Error");
                ListarEmpleados(oBESucursal);
                ListarTodo();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            BESucursal sucursal = (BESucursal)listBox1.SelectedItem;
            ListarEmpleados(sucursal);
        }
    }
}