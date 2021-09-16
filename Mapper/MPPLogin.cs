using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPLogin : IGestor<BELogin>

    {
        public MPPLogin()
        {
            oAcceso = new Acceso();
        }

        private Acceso oAcceso;

        public bool Baja(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        //SELECT Usuario FROM Usuarios WHERE usuario = 'f'
        public BELogin ListarObjeto(BELogin bELogin)
        {
            string consulta = string.Format("SELECT Usuario, Password FROM Usuarios WHERE  Usuario = '{0}' AND Password ='{1}'", bELogin.Usuario,bELogin.Passwd);
            DataTable tabla = oAcceso.Leer(consulta);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                {
                    BELogin oLogin = new BELogin();
                    oLogin.Usuario = item["Usuario"].ToString();
                    oLogin.Passwd = item["Password"].ToString();
                    return oLogin;
                }
            }
            return null;
        }

        public List<BELogin> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}