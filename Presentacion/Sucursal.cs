using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using Negocio;

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
    }
}
