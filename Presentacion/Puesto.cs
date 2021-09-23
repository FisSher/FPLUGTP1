using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Puesto : Form
    {
        public Puesto()
        {
            InitializeComponent();
            oBEPuesto = new BEPuesto();
            oBLLPuesto = new BLLPuesto();
        }

        private BEPuesto oBEPuesto;
        private BLLPuesto oBLLPuesto;

        private void ListarTodo()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = oBLLPuesto.ListarTodo();
            if (oBLLPuesto.ListarTodo().Count>0)
            {
                label3.Text = oBLLPuesto.ListarTodo().Count.ToString();
            }
            else
            {
                label3.Text = "0";
            }
        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            ListarTodo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                oBEPuesto = new BEPuesto();
                oBEPuesto.Nombre = textBox1.Text;
                oBLLPuesto.Guardar(oBEPuesto);
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
                oBEPuesto = (BEPuesto)listBox1.SelectedItem;
                oBEPuesto.Nombre = textBox1.Text;
                oBLLPuesto.Guardar(oBEPuesto);
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
                oBEPuesto = (BEPuesto)listBox1.SelectedItem;
                oBLLPuesto.Baja(oBEPuesto);
                ListarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}