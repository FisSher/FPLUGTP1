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

        public bool Quitar_Sucursal_Empleado(BESucursal bESucursal, BEEmpleado empleado)
        {
            string query = string.Format(" Delete from Empleado_Sucursal where NumSucursal = {0}  and NumEmpleado ={1}", bESucursal.Codigo, empleado.Codigo);
            oDatos = new Acceso();
            return oDatos.Escribir(query);
        }

        public bool Sucursal_Empleado(BESucursal sucursal, BEEmpleado empleado)
        {
            string query = string.Format(@"Insert into Empleado_Sucursal (NumSucursal,NumEmpleado) values ('{0}','{1}')", sucursal.Codigo, empleado.Codigo);
            oDatos = new Acceso();
            return oDatos.Escribir(query);
        }

        public BESucursal ListarObjeto(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BESucursal> ListarTodo()
        {
            DataSet dataSet;
            oDatos = new Acceso();
            string query = $"Select Sucursales.IdSucursal, Sucursales.NombreSuc, Localidades.IdLocalidad,Localidades.Nombre from Sucursales,Localidades where Sucursales.Localidad = Localidades.IdLocalidad";
            dataSet = oDatos.Leer2(query);
            List<BESucursal> ListaSucursales = new List<BESucursal>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
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

                    //Segunda consulta acá estoy hasta las manos
                    //Cada vez que reformatee esta consulta el contador va a aumentar: 7
                    string query2 = string.Format(@"Select IdEmpleado,Empleado.Nombre as Nombre,Empleado.Apellido as Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,FechaEgreso,Antiguedad,Lenguaje_Programacion
                                        from Empleado,Empleado_Sucursal
                                        where Empleado.IdEmpleado = Empleado_Sucursal.NumEmpleado
                                        and Empleado_Sucursal.NumSucursal ={0}", oSucursal.Codigo);
                    Acceso oDatos2 = new Acceso();
                    DataSet Ds2 = new DataSet();
                    Ds2 = oDatos.Leer2(query2);
                    List<BEEmpleado> ListaEmpleados = new List<BEEmpleado>();
                    if (Ds2.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow fila2 in Ds2.Tables[0].Rows)
                        {
                            if (fila2["Lenguaje_Programacion"] is DBNull)
                            {
                                BEEmpleadoMedico empleado = new BEEmpleadoMedico();
                                empleado.Codigo = Convert.ToInt32(fila2[0]);
                                empleado.Nombre = fila2["Nombre"].ToString();
                                empleado.Apellido = fila2["Apellido"].ToString();
                                empleado.DNI = Convert.ToInt32(fila2["DNI"]);
                                empleado.Puesto = Convert.ToInt32(fila2["Puesto"]);
                                empleado.Salario = Convert.ToDouble(fila2["Salario"]);
                                empleado.Baja = Convert.ToInt32(fila2["Baja"]);
                                if (empleado.Baja == 1)
                                    empleado.FechaEgreso = Convert.ToDateTime(fila2["FechaEgreso"]);
                                empleado.FechaIngreso = Convert.ToDateTime(fila2["FechaIngreso"]);

                                ListaEmpleados.Add(empleado);
                            }
                            if (!(fila2["Lenguaje_Programacion"] is DBNull))
                            {
                                BEEmpleadoIT empleado = new BEEmpleadoIT();
                                empleado.Codigo = Convert.ToInt32(fila2[0]);
                                empleado.Nombre = fila2["Nombre"].ToString();
                                empleado.Apellido = fila2["Apellido"].ToString();
                                empleado.DNI = Convert.ToInt32(fila2["DNI"]);
                                empleado.Puesto = Convert.ToInt32(fila2["Puesto"]);
                                empleado.Salario = Convert.ToDouble(fila2["Salario"]);
                                empleado.Baja = Convert.ToInt32(fila2["Baja"]);
                                if (empleado.Baja == 1)
                                    empleado.FechaEgreso = Convert.ToDateTime(fila2["FechaEgreso"]);
                                empleado.FechaIngreso = Convert.ToDateTime(fila2["FechaIngreso"]);
                                empleado.Antiguedad = Convert.ToInt32(fila2["Antiguedad"]);
                                empleado.Lenguaje = fila2["Lenguaje_Programacion"].ToString();

                                ListaEmpleados.Add(empleado);
                            }
                        }

                        oSucursal.ListaEmplados = ListaEmpleados;
                    }

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