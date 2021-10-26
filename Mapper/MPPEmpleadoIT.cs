using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPEmpleadoIT : IGestor<BEEmpleadoIT>
    {
        public MPPEmpleadoIT()
        {
            oDatos = new Acceso();
        }
        Hashtable Hdatos;
        private Acceso oDatos;

        public bool Baja(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleadoIT e)
        {
            //sp: S_Empleado_BajaLogica
            Hdatos = new Hashtable();
            Hdatos.Add("@FechaE", DateTime.Now.ToShortDateString());
            Hdatos.Add("@Cod", e.Codigo);
            string query = "S_Empleado_BajaLogica";

            return oDatos.Escribir(query,Hdatos);

        }

        public bool Guardar(BEEmpleadoIT e)
        {
            Hdatos = new Hashtable();
            string query;
            if (e.Codigo == 0)
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    //sp: S_EmpleadoIT_Crear
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@FechaE", e.FechaEgreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    Hdatos.Add("@LP", e.Lenguaje);
                    query = "S_EmpleadoIT_Crear";
                    return oDatos.Escribir(query,Hdatos);
                }
                else
                {
                    //sp: S_EmpleadoIT_CrearNOEgresado
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    Hdatos.Add("@LP", e.Lenguaje);
                    query = "S_EmpleadoIT_CrearNOEgresado";
                    return oDatos.Escribir(query,Hdatos);
                }
            }
            else
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    //sp: S_EmpleadoIT_UpdateEgresado
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@FechaE", e.FechaEgreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    Hdatos.Add("@LP", e.Lenguaje);
                    Hdatos.Add("@Cod", e.Lenguaje);
                    query = "S_EmpleadoIT_UpdateEgresado";
                    return oDatos.Escribir(query,Hdatos);
                }
                else
                {
                    //TODO:  S_EmpleadoIT_UpdateNOEgresado
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    Hdatos.Add("@LP", e.Lenguaje);
                    Hdatos.Add("@Cod", e.Lenguaje);
                    query = "S_EmpleadoIT_UpdateNOEgresado";
                    return oDatos.Escribir(query,Hdatos);
                }
            }
        }
        //sp: S_Empleado_GuardarEnSucursal
        public bool GuardarEnSucursal(BESucursal sucursal, BEEmpleadoIT empleado)
        {
            string query;
            BEEmpleadoIT empleadoBuscado = new BEEmpleadoIT();
            empleadoBuscado = ListarObjeto(empleado);
            if (empleadoBuscado.Codigo == 0)
            {
                return false;
            }
            else
            {
                Hdatos.Add("@CodEmpl", empleado.Codigo);
                Hdatos.Add("@CodSuc", sucursal.Codigo);
                query = "S_Empleado_GuardarEnSucursal";
                return oDatos.Escribir(query, Hdatos);
            }
        }

        public BEEmpleadoIT ListarObjeto(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEmpleadoIT> ListarTodo()
        {
            DataTable tabla;
            oDatos = new Acceso();
            //TODO: S_EmpleadoIT_ListarTodo
            tabla = oDatos.Leer("S_Empleado_ListarTodo",null);
            List<BEEmpleadoIT> LEmpleadosIT = new List<BEEmpleadoIT>();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                {
                    if (!(item["Lenguaje_Programacion"] is DBNull))
                    {
                        BEEmpleadoIT empleado = new BEEmpleadoIT();
                        empleado.Codigo = Convert.ToInt32(item[0]);
                        empleado.Nombre = item["Nombre"].ToString();
                        empleado.Apellido = item["Apellido"].ToString();
                        empleado.DNI = Convert.ToInt32(item["DNI"]);
                        empleado.Puesto = Convert.ToInt32(item["Puesto"]);
                        empleado.Salario = Convert.ToDouble(item["Salario"]);
                        empleado.Baja = Convert.ToInt32(item["Baja"]);
                        if (empleado.Baja == 1)
                            empleado.FechaEgreso = Convert.ToDateTime(item["FechaEgreso"]);
                        empleado.FechaIngreso = Convert.ToDateTime(item["FechaIngreso"]);
                        empleado.Antiguedad = Convert.ToInt32(item["Antiguedad"]);
                        empleado.Lenguaje = item["Lenguaje_Programacion"].ToString();
                        LEmpleadosIT.Add(empleado);
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                LEmpleadosIT = null;
            }
            return LEmpleadosIT;
        }
    }
}