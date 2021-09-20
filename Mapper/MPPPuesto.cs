using Abstraccion;
using BE;
using DAL;
using System;
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

        public bool Baja(BEPuesto Objeto)
        {
            string query;
            query = $"DELETE FROM Puesto where IdPuesto = '{Objeto.Codigo}'";
            oDatos = new Acceso();
            return oDatos.Escribir(query);
        }

 
        public bool BajaLogica(BEPuesto Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEPuesto puesto)
        {
            string query;
            if (puesto.Codigo == 0)
            {
                query = $"Insert into Puesto(Nombre) values('{puesto.Nombre}')";
            }
            else
            {
                query = $"UPDATE Puesto SET Nombre='{puesto.Nombre}' where IdPuesto ='{puesto.Codigo}'";
            }
            oDatos = new Acceso();
            return oDatos.Escribir(query);
        }

        public BEPuesto ListarObjeto(BEPuesto Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEPuesto> ListarTodo()
        {
            DataTable tabla;
            oDatos = new Acceso();
            tabla = oDatos.Leer("SELECT IdPuesto,Nombre FROM Puesto");
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