using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPLogin : IGestor<BELogin>

    {
        public MPPLogin()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;
        Hashtable Hdatos;
        public bool Baja(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public bool ExisteUsuario(BELogin bELogin)
        {
            //SP: S_Usuario_ExisteUsuario
            Hdatos = new Hashtable();
            Hdatos.Add("@Nom", bELogin.Usuario);
            
            
            return oDatos.LeerEscalar("S_Usuario_ExisteUsuario", Hdatos);
        }

        public bool Guardar(BELogin Objeto)
        {
            //SP: S_Usuario_Guardar
            Hdatos = new Hashtable();
            Hdatos.Add("@Nom", Objeto.Usuario);
            Hdatos.Add("@Pas", Objeto.Passwd);

            if (ExisteUsuario(Objeto))
            {
                return false;
            }
            else
            {
                return oDatos.Escribir("S_Usuario_Guardar", Hdatos);
            }
        }

        public BELogin ListarObjeto(BELogin bELogin)
        {// SP: S_Usuario_ListarObjeto

            Hdatos = new Hashtable();
            Hdatos.Add("@Nom", bELogin.Usuario);
            Hdatos.Add("@Pas", bELogin.Passwd);
            DataTable tabla = oDatos.Leer("S_Usuario_ListarObjeto", Hdatos);
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