using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MPPEmpleadoMedico : IGestor<BEEmpleadoMedico>
    {
        public MPPEmpleadoMedico()
        {
            oDatos = new Acceso();
        }
        private Hashtable Hdatos;

        private Acceso oDatos;

        public bool Baja(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleadoMedico e)
        {//sp: S_Empleado_BajaLogica
            Hdatos = new Hashtable();
            Hdatos.Add("@FechaE", DateTime.Now.ToShortDateString());
            Hdatos.Add("@Cod", e.Codigo);
            string query = "S_Empleado_BajaLogica";
            return oDatos.Escribir(query,Hdatos);
        }

        public bool Guardar(BEEmpleadoMedico e)
        {
            Hdatos = new Hashtable();
            string query;
            if (e.Codigo == 0)
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    //sp: S_EmpleadoMedico_Crear
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@FechaE", e.FechaEgreso);
                    Hdatos.Add("@Ant", e.Antiguedad);

                    query = "S_EmpleadoMedico_Crear";
                    return oDatos.Escribir(query,Hdatos);
                }
                else
                {
                    //sp: S_EmpleadoMedico_CrearNOEgresado
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    query = "S_EmpleadoMedico_CrearNOEgresado";
                    return oDatos.Escribir(query,Hdatos);
                }
            }
            else
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {//sp: S_EmpleadoMedico_UpdateEgresado

                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@FechaE", e.FechaEgreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    Hdatos.Add("@Cod", e.Codigo);
                    query = "S_EmpleadoMedico_UpdateEgresado";


                    return oDatos.Escribir(query,Hdatos);
                }
                else
                {//sp: S_EmpleadoMedico_UpdateNOEgresado
                    Hdatos.Add("@Nom", e.Nombre);
                    Hdatos.Add("@Ape", e.Apellido);
                    Hdatos.Add("@Dni", e.DNI);
                    Hdatos.Add("@Puesto", e.Puesto);
                    Hdatos.Add("@Salario", e.Salario);
                    Hdatos.Add("@Baja", e.Baja);
                    Hdatos.Add("@FechaI", e.FechaIngreso);
                    Hdatos.Add("@Ant", e.Antiguedad);
                    Hdatos.Add("@Cod", e.Codigo);
                    query = "S_EmpleadoMedico_UpdateNOEgresado";
                    return oDatos.Escribir(query,Hdatos);
                }
            }
        }

        //sp: S_Empleado_GuardarEnSucursal
        public bool GuardarEnSucursal(BESucursal sucursal, BEEmpleadoMedico empleado)
        {
            string query;
            Hdatos = new Hashtable();
            BEEmpleadoMedico empleadoBuscado = new BEEmpleadoMedico();
            empleadoBuscado = ListarObjeto(empleado);
            if (empleadoBuscado.Codigo == 0)
            {
                return false;
            }
            else
            {
                Hdatos.Add("@CodEmpl", empleado.Codigo);
                Hdatos.Add("@CodSuc",sucursal.Codigo);
                query = "S_Empleado_GuardarEnSucursal";
                return oDatos.Escribir(query,Hdatos);
            }
        }

        public BEEmpleadoMedico ListarObjeto(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        //SP: S_Empleado_ListarTodo
        public List<BEEmpleadoMedico> ListarTodo()
        {
            DataTable tabla;
            oDatos = new Acceso();
            tabla = oDatos.Leer("S_Empleado_ListarTodo",null);
            List<BEEmpleadoMedico> LEmpleadosMedico = new List<BEEmpleadoMedico>();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow item in tabla.Rows)
                {
                    if (item["Lenguaje_Programacion"] is DBNull)
                    {
                        BEEmpleadoMedico empleado = new BEEmpleadoMedico();
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

                        LEmpleadosMedico.Add(empleado);
                    }
                }
            }
            else
            {
                LEmpleadosMedico = null;
            }
            return LEmpleadosMedico;
        }
    }
}