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
    public partial class LoginUC : UserControl
    {


        private BELogin bELogin;
        private BLLogin bLogin;
        public LoginUC()
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

        private void LoginUC_Load(object sender, EventArgs e)
        {

        }
    }
}
