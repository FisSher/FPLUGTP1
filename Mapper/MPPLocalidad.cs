using Abstraccion;
using BE;
using DAL;
using System;
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

        public bool Baja(BELocalidad localidad)
        {
            if (ExisteSucursalAsociada(localidad))
            {
                return false;
            }
            else
            {
                string query = $"DELETE FROM Localidades where IdLocalidad = '{localidad.Codigo}'";
                oDatos = new Acceso();
                return oDatos.Escribir(query);
            }
        }

        private bool ExisteSucursalAsociada(BELocalidad loc)
        {
            oDatos = new Acceso();
            return oDatos.LeerEscalar($"Select count(Localidad) from Sucursales where Localidad = '{loc.Codigo}'");
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
            string consulta;
            if (Objeto.Codigo != 0)
            {
                consulta = string.Format("UPDATE Localidades SET Nombre = '{0}' where IdLocalidad = '{1}'", Objeto.Nombre, Objeto.Codigo);
            }
            else
            {
                consulta = $"Insert into Localidades(Nombre) VALUES('{Objeto.Nombre}')";
            }
            oDatos = new Acceso();
            return oDatos.Escribir(consulta);
        }

        public List<BELocalidad> ListarTodo()
        {
            DataTable tabla;
            oDatos = new Acceso();
            tabla = oDatos.Leer("Select IdLocalidad,Nombre From Localidades");
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