using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using BE;

namespace Presentacion
{
    public partial class Login : Form
    {
        BELogin bELogin;
        BLLogin bLogin;

        public Login()
        {
            InitializeComponent();
            bELogin = new BELogin();
            bLogin = new BLLogin();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bELogin.Usuario = textBoxUsuario.Text;
            bELogin.Passwd = textBoxContra.Text;
            if (bLogin.ListarObjeto(bELogin) != null)
            {
                this.Hide();
                Aplicacion oAplicacion = new Aplicacion();
                oAplicacion.Show();
            }
            else
            {
                MessageBox.Show("Error de login");
            }
            
        }
    }
}
