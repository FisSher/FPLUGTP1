using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Localidad : Form
    {
        private BELocalidad oBELocalidad;
        private BLLLocalidad oBLLLocalidad;

        public Localidad()
        {
            InitializeComponent();
            oBELocalidad = new BELocalidad();
            oBLLLocalidad = new BLLLocalidad();
        }

        private void CargarLista()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = oBLLLocalidad.ListarTodo();
            if (oBLLLocalidad.ListarTodo().Count>0)
            {
                label3.Text = oBLLLocalidad.ListarTodo().Count.ToString();
            }
            else
            {
            label3.Text = "0";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                oBELocalidad = new BELocalidad();
                oBELocalidad.Nombre = textBox1.Text;
                oBLLLocalidad.Guardar(oBELocalidad);
                CargarLista();
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Localidad_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                oBELocalidad = (BELocalidad)listBox1.SelectedItem;
                oBELocalidad.Nombre = textBox1.Text;
                oBLLLocalidad.Guardar(oBELocalidad);
                CargarLista();
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
                oBELocalidad = (BELocalidad)listBox1.SelectedItem;
                bool res = oBLLLocalidad.Baja(oBELocalidad);
                if (!res)
                {
                    MessageBox.Show("No se puede borrar esta localidad, tiene sucursales asociadas");
                }
                CargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}