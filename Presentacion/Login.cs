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
            ValidacionesRegex validacion = new ValidacionesRegex();
            if (validacion.ValidarAlfanumerico(textBoxUsuario.Text) && validacion.ValidarAlfanumerico(textBoxContra.Text))
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
            else
            {
                MessageBox.Show("Solo caracteres alfanumericos permitidos", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidacionesRegex validacion = new ValidacionesRegex();
            if (validacion.ValidarAlfanumerico(textBoxUsuario.Text) && validacion.ValidarAlfanumerico(textBoxContra.Text))
            {
                try

                {
                    bELogin.Usuario = textBoxUsuario.Text;
                    bELogin.Passwd = textBoxContra.Text;
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
            else
            {
                MessageBox.Show("Solo caracteres alfanumericos permitidos", "Error");
            }
        }
    }
}