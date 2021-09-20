using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Login : Form
    {
        private BELogin bELogin;
        private BLLogin bLogin;

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

        private void button1_Click(object sender, EventArgs e)
        {

            bELogin.Usuario = textBoxUsuario.Text;
            bELogin.Passwd = textBoxContra.Text;
            try
            {
                bool exito = bLogin.Guardar(bELogin);
                if (!exito)
                {
                    MessageBox.Show("El usuario ya existe");
                }
                else
                {
                    MessageBox.Show("Registrado con exito");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}