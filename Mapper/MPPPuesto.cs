using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPPuesto : IGestor<BEPuesto>
    {
        public MPPPuesto()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;
        Hashtable Hdatos;

        public bool Baja(BEPuesto Objeto)
        {//SP:S_Puesto_Baja
 
            Hdatos = new Hashtable();
            Hdatos.Add("@Cod", Objeto.Codigo);

            return oDatos.Escribir("S_Puesto_Baja", Hdatos);
        }

        public bool BajaLogica(BEPuesto Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEPuesto puesto)
        {
            string storedProcedure;
            Hdatos = new Hashtable();
            if (puesto.Codigo == 0)
            {//SP: S_Puesto_Crear
                storedProcedure = "S_Puesto_Crear";
                Hdatos.Add("@Nom", puesto.Nombre);

            }
            else
            {//SP: S_Puesto_Update
                storedProcedure = "S_Puesto_Update";
                Hdatos.Add("@Cod", puesto.Codigo);
                Hdatos.Add("@Nom", puesto.Nombre);
            }

            return oDatos.Escribir(storedProcedure,Hdatos);
        }

        public BEPuesto ListarObjeto(BEPuesto Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEPuesto> ListarTodo()
        {
            //SP: S_Puesto_ListarTodo
            DataTable tabla;
            Hdatos = new Hashtable();

            tabla = oDatos.Leer("S_Puesto_ListarTodo",null);
            List<BEPuesto> ListaPuestos = new List<BEPuesto>();
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                {
                    BEPuesto oPuesto = new BEPuesto();
                    oPuesto.Codigo = Convert.ToInt32(item[0]);
                    oPuesto.Nombre = item["Nombre"].ToString();
                    ListaPuestos.Add(oPuesto);
                }
            }
            else
            {
                ListaPuestos = null;
            }
            return ListaPuestos;
        }
    }
}