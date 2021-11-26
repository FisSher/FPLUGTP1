using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
using Negocio;

namespace Presentacion
{
    public partial class Informes : Form
    {
        private BLLEmpleadoIT oEmpleadoIT;
        private BLLEmpleadoMedico oEmpleadoMedico;
        public Informes()
        {
            InitializeComponent();
            oEmpleadoIT = new BLLEmpleadoIT();
            oEmpleadoMedico = new BLLEmpleadoMedico();
        }

        void CargarGraficos1()
        {
            List<BEEmpleadoIT> LEmpIT = oEmpleadoIT.ListarTodo();
            List<BEEmpleadoMedico> LEmpMedico = oEmpleadoMedico.ListarTodo();
            Dictionary<int, double> ListaDatos = new Dictionary<int, double>();

            foreach (BEEmpleadoIT objeto in LEmpIT)
            {
                BEEmpleadoIT e = new BEEmpleadoIT();
                e = objeto;
                ListaDatos.Add(e.Codigo, e.Salario);

            }
            foreach (BEEmpleadoMedico objeto in LEmpMedico)
            {
                BEEmpleadoMedico e = new BEEmpleadoMedico();
                e = objeto;
                ListaDatos.Add(e.Codigo, e.Salario);

            }
            #region chart1
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

            Title Titulo = new Title("Distribución de salarios");
            Titulo.Font = new Font("Tahoma", 10, FontStyle.Regular);
            chart1.Titles.Add(Titulo);

            ChartArea Area = new ChartArea();
            chart1.ChartAreas.Add(Area);


            Series serie = new Series("salario");
            serie.Points.DataBindXY(ListaDatos.Keys, ListaDatos.Values);
            serie.ChartType = SeriesChartType.Point;
            chart1.Series.Add(serie);
            #endregion




            #region chart2
            Dictionary<string, int> ListaDatos2 = new Dictionary<string, int>();
            ListaDatos2.Add("Activo", 0);
            ListaDatos2.Add("Baja", 0);

            foreach (var e in LEmpIT)
            {
                if (e.Baja==1)
                {
                    ListaDatos2["Baja"] += 1;
                }
                else
                {
                    ListaDatos2["Activo"] += 1;
                }
            }
            foreach (var e in LEmpMedico)
            {
                if (e.Baja == 1)
                {
                    ListaDatos2["Baja"] += 1;
                }
                else
                {
                    ListaDatos2["Activo"] += 1;
                }
            }




            chart2.Titles.Clear();
            chart2.ChartAreas.Clear();
            chart2.Series.Clear();

            Title Titulo2 = new Title("Empleados activos vs dados de baja");
            Titulo2.Font = new Font("Tahoma", 10, FontStyle.Regular);
            chart2.Titles.Add(Titulo2);

            ChartArea Area2 = new ChartArea();
            chart2.ChartAreas.Add(Area2);
            Area2.Area3DStyle.Enable3D = true;



            Series serie2 = new Series("Actividad");
            serie2.Points.DataBindXY(ListaDatos2.Keys, ListaDatos2.Values);
            serie2.ChartType = SeriesChartType.Bar;
            chart2.Series.Add(serie2);
            #endregion

        }

        private void Informes_Load(object sender, EventArgs e)
        {
            CargarGraficos1();
        }
    }
}
