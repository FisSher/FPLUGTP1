using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Empleados : Form
    {
        private BLLEmpleadoIT oEmpleadoIT;
        private BLLEmpleadoMedico oEmpleadoMedico;
        private BLLSucursal oSucursal;
        private BLLPuesto oPuesto;

        public Empleados()
        {
            InitializeComponent();
            oEmpleadoIT = new BLLEmpleadoIT();
            oEmpleadoMedico = new BLLEmpleadoMedico();
            oSucursal = new BLLSucursal();
            oPuesto = new BLLPuesto();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            CargarGrillaMedicos();
            CargarGrillaIT();
            CargarCombo();
            CargarSucursales();
        }

        private void CargarGrillaMedicos()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oEmpleadoMedico.ListarTodo();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void CargarGrillaIT()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = oEmpleadoIT.ListarTodo();
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void CargarCombo()
        {
            this.comboBox1.DataSource = null;
            this.comboBox1.DataSource = oPuesto.ListarTodo();
        }

        private void CargarSucursales()
        {
            this.listBoxSucursales.DataSource = null;
            this.listBoxSucursales.DataSource = oSucursal.ListarTodo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxLeng.Text))
                {
                    BEEmpleadoMedico empleado = new BEEmpleadoMedico();
                    empleado.Nombre = textBoxNombre.Text;
                    empleado.Apellido = textBoxApellido.Text;
                    empleado.DNI = Convert.ToInt32(textBoxDNI.Text);
                    BEPuesto puesto = (BEPuesto)comboBox1.SelectedItem;
                    empleado.Puesto = puesto.Codigo;
                    empleado.Salario = Convert.ToDouble(textBoxSalario.Text);
                    empleado.Calcular_Salario();
                    empleado.Baja = 0;
                    empleado.FechaIngreso = dateTimePicker1.Value;
                    empleado.FechaEgreso = dateTimePicker2.Value;
                    oEmpleadoMedico.Guardar(empleado);
                    CargarGrillaMedicos();
                }
                else
                {
                    BEEmpleadoIT empleadoIT = new BEEmpleadoIT();
                    empleadoIT.Nombre = textBoxNombre.Text;
                    empleadoIT.Apellido = textBoxApellido.Text;
                    empleadoIT.DNI = Convert.ToInt32(textBoxDNI.Text);
                    BEPuesto puesto = (BEPuesto)comboBox1.SelectedItem;
                    empleadoIT.Puesto = puesto.Codigo;
                    empleadoIT.Salario = Convert.ToDouble(textBoxSalario.Text);
                    empleadoIT.Calcular_Salario();
                    empleadoIT.Baja = 0;
                    empleadoIT.FechaIngreso = dateTimePicker1.Value;
                    empleadoIT.FechaEgreso = dateTimePicker2.Value;
                    empleadoIT.Lenguaje = textBoxLeng.Text;
                    oEmpleadoIT.Guardar(empleadoIT);
                    CargarGrillaIT();
                }
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
                if (radioButton1.Checked)
                {
                    BEEmpleadoMedico empleadoMedico = (BEEmpleadoMedico)dataGridView1.CurrentRow.DataBoundItem;
                    empleadoMedico.Nombre = textBoxNombre.Text;
                    empleadoMedico.Apellido = textBoxApellido.Text;
                    empleadoMedico.DNI = Convert.ToInt32(textBoxDNI.Text);
                    BEPuesto puesto = (BEPuesto)comboBox1.SelectedItem;
                    empleadoMedico.Puesto = puesto.Codigo;
                    empleadoMedico.Salario = Convert.ToDouble(textBoxSalario.Text);
                    empleadoMedico.Calcular_Salario();
                    empleadoMedico.Baja = 0;
                    empleadoMedico.FechaIngreso = dateTimePicker1.Value;
                    empleadoMedico.FechaEgreso = dateTimePicker2.Value;
                    oEmpleadoMedico.Guardar(empleadoMedico);
                    CargarGrillaMedicos();
                }
                else if (radioButton2.Checked)
                {
                    BEEmpleadoIT empleadoIT = (BEEmpleadoIT)dataGridView2.CurrentRow.DataBoundItem;
                    empleadoIT.Nombre = textBoxNombre.Text;
                    empleadoIT.Apellido = textBoxApellido.Text;
                    empleadoIT.DNI = Convert.ToInt32(textBoxDNI.Text);
                    BEPuesto puesto = (BEPuesto)comboBox1.SelectedItem;
                    empleadoIT.Puesto = puesto.Codigo;
                    empleadoIT.Salario = Convert.ToDouble(textBoxSalario.Text);
                    empleadoIT.Calcular_Salario();
                    empleadoIT.Baja = 0;
                    empleadoIT.FechaIngreso = dateTimePicker1.Value;
                    empleadoIT.FechaEgreso = dateTimePicker2.Value;
                    empleadoIT.Lenguaje = textBoxLeng.Text;
                    oEmpleadoIT.Guardar(empleadoIT);
                    CargarGrillaIT();
                }
                else
                {
                    MessageBox.Show("Seleccione un radiobutton");
                }
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
                if (radioButton1.Checked)
                {
                    BEEmpleadoMedico empleadoMedico = (BEEmpleadoMedico)dataGridView1.CurrentRow.DataBoundItem;

                    empleadoMedico.Baja = 1;
                    empleadoMedico.FechaIngreso = dateTimePicker1.Value;
                    empleadoMedico.FechaEgreso = dateTimePicker2.Value;
                    if (empleadoMedico.FechaEgreso > empleadoMedico.FechaIngreso)
                    {
                        oEmpleadoMedico.BajaLogica(empleadoMedico);
                        CargarGrillaMedicos();
                    }
                    else
                    {
                        MessageBox.Show("La fecha de egreso tiene que ser mayor a la de ingreso");
                    }
                }
                else if (radioButton2.Checked)
                {
                    BEEmpleadoIT empleadoIT = (BEEmpleadoIT)dataGridView2.CurrentRow.DataBoundItem;

                    empleadoIT.Baja = 1;
                    empleadoIT.FechaIngreso = dateTimePicker1.Value;
                    empleadoIT.FechaEgreso = dateTimePicker2.Value;
                    if (empleadoIT.FechaEgreso > empleadoIT.FechaIngreso)
                    {
                        oEmpleadoIT.BajaLogica(empleadoIT);
                        CargarGrillaIT();
                    }
                    else
                    {
                        MessageBox.Show("La fecha de egreso tiene que ser mayor a la de ingreso");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un radiobutton");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void buttonAsignaIT_Click(object sender, EventArgs e)
        {

        }
        //No se que iba a hacer con esto
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
    }
}