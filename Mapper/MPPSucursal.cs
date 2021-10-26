using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
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
        Hashtable Hdatos;


        public bool Baja(BESucursal suc)
        {
            //SP: S_Sucursal_Baja
            Hdatos = new Hashtable();
            Hdatos.Add("@Cod",suc.Codigo);
            string query = "S_Sucursal_Baja";

            return oDatos.Escribir(query, Hdatos);
        }

        public bool BajaLogica(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BESucursal sucursal)
        {
            Hdatos = new Hashtable();
            string query;
            if (sucursal.Codigo == 0)
            {//SP: S_Sucursal_Crear
                query = "S_Sucursal_Crear";
                Hdatos.Add("@Nom", sucursal.Nombre);
                Hdatos.Add("@Cod", sucursal.Localidad.Codigo);

            }
            else
            {//SP:S_Sucursal_Update
                query = "S_Sucursal_Update";
                Hdatos.Add("@Nom", sucursal.Nombre);
                Hdatos.Add("@CodLoc", sucursal.Localidad.Codigo);
                Hdatos.Add("@Cod", sucursal.Codigo);
            }
            oDatos = new Acceso();
            return oDatos.Escribir(query,Hdatos);
        }

        public bool Quitar_Sucursal_Empleado(BESucursal bESucursal, BEEmpleado empleado)
        {
            //SP: S_Sucursal_QuitarEmpleado
            string query = "S_Sucursal_QuitarEmpleado";
            Hdatos = new Hashtable();
            Hdatos.Add("@CodEmpleado", empleado.Codigo);
            Hdatos.Add("@Cod", bESucursal.Codigo);

            return oDatos.Escribir(query,Hdatos);
        }

        public bool Sucursal_Empleado(BESucursal sucursal, BEEmpleado empleado)
        {
            //sp: S_Sucursal_Empleado
            Hdatos = new Hashtable();
            string query = "S_Sucursal_Empleado";
            Hdatos.Add("@CodEmpleado", empleado.Codigo);
            Hdatos.Add("@Cod", sucursal.Codigo);
            return oDatos.Escribir(query,Hdatos);
        }

        public BESucursal ListarObjeto(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BESucursal> ListarTodo()
        {
            Hdatos = new Hashtable();

            DataSet dataSet;
            oDatos = new Acceso();
            //sp: S_Sucursal_ListarTodo
            string query = "S_Sucursal_ListarTodo";
            dataSet = oDatos.Leer2(query,null);
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
                    //Cada vez que reformatee esta consulta el contador va a aumentar:   > 12< 

                    //sp: S_Sucursal_ListarTodoParteDos
                    string query2 = "S_Sucursal_ListarTodoParteDos";
                    Hdatos.Add("@Cod", oSucursal.Codigo);
                    Acceso oDatos2 = new Acceso();
                    DataSet Ds2 = new DataSet();
                    Ds2 = oDatos.Leer2(query2,Hdatos);
                    Hdatos.Clear();
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