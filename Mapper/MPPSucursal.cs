using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPSucursal : IGestor<BESucursal>
    {
        public MPPSucursal()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;

        public bool Baja(BESucursal suc)
        {
            string query = $"DELETE FROM Puesto where IdPuesto = '{suc.Codigo}'";
            oDatos = new Acceso();
            return oDatos.Escribir(query);
        }

        public bool BajaLogica(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BESucursal sucursal)
        {
            string query;
            if (sucursal.Codigo == 0)
            {
                query = $"Insert into Sucursales (NombreSuc,Localidad) values ('{sucursal.Nombre}','{sucursal.Localidad.Codigo}')";
            }
            else
            {
                query = $"UPDATE Sucursales SET NombreSuc = '{sucursal.Nombre}', Localidad = '{sucursal.Localidad.Codigo}' where IdSucursal = '{sucursal.Codigo}'";
            }
            oDatos = new Acceso();
            return oDatos.Escribir(query);
        }

        public BESucursal ListarObjeto(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BESucursal> ListarTodo()
        {
            DataTable tabla;
            oDatos = new Acceso();
            string query = $"Select Sucursales.IdSucursal, Sucursales.NombreSuc, Localidades.IdLocalidad,Localidades.Nombre from Sucursales,Localidades where Sucursales.Localidad = Localidades.IdLocalidad";
            tabla = oDatos.Leer(query);
            List<BESucursal> ListaSucursales = new List<BESucursal>();
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                {
                    //Agrego la sucursal
                    BESucursal oSucursal = new BESucursal();
                    oSucursal.Codigo = Convert.ToInt32(item[0]);
                    oSucursal.Nombre = item["NombreSuc"].ToString();
                    //Agrego su respectivo obj localidad
                    BELocalidad LocalidadTabla = new BELocalidad();
                    LocalidadTabla.Codigo = Convert.ToInt32(item[2]);
                    LocalidadTabla.Nombre = item["Nombre"].ToString();
                    //Agrego la localidad al objeto principal y asigno a lista.
                    oSucursal.Localidad = LocalidadTabla;
                    ListaSucursales.Add(oSucursal);
                }
            }
            else
            {
                ListaSucursales = null;
            }
            return ListaSucursales;
        }
    }
}