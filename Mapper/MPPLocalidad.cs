using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPLocalidad : IGestor<BELocalidad>
    {
        public MPPLocalidad()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;
        private Hashtable Hdatos;

        public bool Baja(BELocalidad localidad)
        {
            if (ExisteSucursalAsociada(localidad))
            {
                return false;
            }
            else
            {
                Hdatos = new Hashtable();
                //sp: S_Localidad_Baja
                string query = "S_Localidad_Baja";
                Hdatos.Add("@Cod", localidad.Codigo);
                return oDatos.Escribir(query,Hdatos);
            }
        }

        private bool ExisteSucursalAsociada(BELocalidad loc)
        {
            //SP: S_Localidad_SucAsociada
            Hdatos = new Hashtable();
            Hdatos.Add("@Cod", loc.Codigo);

            return oDatos.LeerEscalar("S_Localidad_SucAsociada",Hdatos);
        }

        public bool BajaLogica(BELocalidad Objeto)
        {
            throw new NotImplementedException();
        }

        public BELocalidad ListarObjeto(BELocalidad Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BELocalidad Objeto)
        {
            Hdatos = new Hashtable();
            
            string consulta;
            if (Objeto.Codigo != 0)
            {//sp: S_Localidad_Update
                Hdatos.Add("@Cod", Objeto.Codigo);
                Hdatos.Add("@Nom", Objeto.Nombre);
                consulta = "S_Localidad_Update";
            }
            else
            {//sp: S_Localidad_Crear
                Hdatos.Add("@Nom", Objeto.Nombre);
                consulta = "S_Localidad_Crear";
            }
            oDatos = new Acceso();
            return oDatos.Escribir(consulta,Hdatos);
        }

        public List<BELocalidad> ListarTodo()
        {
            //sp: S_Localidad_ListarTodo
            DataTable tabla;
            oDatos = new Acceso();
            tabla = oDatos.Leer("S_Localidad_ListarTodo",null);
            List<BELocalidad> ListaLocalidades = new List<BELocalidad>();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                {
                    BELocalidad oBELoc = new BELocalidad();
                    oBELoc.Codigo = Convert.ToInt32(item[0]);
                    oBELoc.Nombre = item["Nombre"].ToString();
                    ListaLocalidades.Add(oBELoc);
                }
            }
            else
            {
                ListaLocalidades = null;
            }
            return ListaLocalidades;
        }
    }
}