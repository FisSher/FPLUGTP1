using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Ambulancia : Form
    {
        private BLLAmbulancia BLLAmbulancia;
        private BEEAmbulancia oBEEAmbulancia;

        public Ambulancia()
        {
            InitializeComponent();
            BLLAmbulancia = new BLLAmbulancia();
        }

        private void Ambulancia_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BLLAmbulancia.CargarXML();
                dataGridView1.Columns["NumAmbulancia"].DisplayIndex = 0;
                dataGridView1.Columns["NumAmbulancia"].HeaderText = "Codigo ambulancia";
                dataGridView1.Columns["CantPasajeros"].DisplayIndex = 1;
                dataGridView1.Columns["CantPasajeros"].HeaderText = "Cantidad de pasajeros";
                dataGridView1.Columns["EnServicio"].DisplayIndex = 2;
                dataGridView1.Columns["EnServicio"].HeaderText = "En servicio";
                dataGridView1.Columns["Emergencia"].DisplayIndex = 3;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tipoBusqueda = comboBox1.Text;
            ValidacionesRegex validaciones = new ValidacionesRegex();

            try
            {
                switch (tipoBusqueda)
                {
                    case "En servicio":
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = BLLAmbulancia.BuscarXML("Servicio", "si");
                        break;

                    case "Emergencia":
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = BLLAmbulancia.BuscarXML("Emergencia", "si");
                        break;

                    case "Codigo":

                        if (validaciones.ValidarSoloNumero(textBoxBusq.Text))
                        {
                            string codigo = textBoxBusq.Text;
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = BLLAmbulancia.BuscarXML("Numero", textBoxBusq.Text);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese un número en textbox buscar", "Error!");
                        }
                        break;

                    case "Pasajeros":
                        if (validaciones.ValidarSoloNumero(textBoxBusq.Text))
                        {
                            string pasajeros = textBoxBusq.Text;
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = BLLAmbulancia.BuscarXML("Pasajeros", textBoxBusq.Text);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese un número en textbox buscar", "Error!");
                        }
                        break;
                    default:
                        MessageBox.Show("Seleccione metodo de busqueda");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            ValidacionesRegex validaciones = new ValidacionesRegex();
            if (validaciones.ValidarSoloNumero(textBoxCod.Text) && validaciones.ValidarSoloNumero(textBoxPasajeros.Text))
            {
                oBEEAmbulancia = new BEEAmbulancia(
                              Convert.ToInt32(textBoxCod.Text),
                              checkBoxServicio.Checked,
                              checkBoxEmergencia.Checked,
                              Convert.ToInt32(textBoxPasajeros.Text)
                              );
                BLLAmbulancia.AgregarXML(oBEEAmbulancia);
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("El código y pasajeros sólo admite números", "Error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oBEEAmbulancia = (BEEAmbulancia)dataGridView1.CurrentRow.DataBoundItem;
            BLLAmbulancia.BorrarXML(oBEEAmbulancia.NumAmbulancia.ToString());
            MessageBox.Show("Eliminado.");
            CargarGrilla();
        }
    }
}