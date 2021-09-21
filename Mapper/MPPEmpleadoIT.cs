using Abstraccion;
using BE;
using DAL;
using System;
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

        private Acceso oDatos;

        public bool Baja(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleadoIT e)
        {
            string query = $"UPDATE Empleado SET Baja=1, FechaEgreso = '{DateTime.Now.ToShortDateString()}' where IdEmpleado='{e.Codigo}'";
            return oDatos.Escribir(query);
        }

        public bool Guardar(BEEmpleadoIT e)
        {
            string query;
            if (e.Codigo == 0)
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    query = $"Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad,Lenguaje_Programacion,FechaEgreso) values ('{e.Nombre}','{e.Apellido}','{e.DNI}','{e.Puesto}','{e.Salario}','{e.Baja}','{e.FechaIngreso}','{e.Antiguedad}','{e.Lenguaje}','{e.FechaEgreso}')";
                    return oDatos.Escribir(query);
                }
                else
                {
                    query = $"Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad,Lenguaje_Programacion) values ('{e.Nombre}','{e.Apellido}','{e.DNI}','{e.Puesto}','{e.Salario}','{e.Baja}','{e.FechaIngreso}','{e.Antiguedad}','{e.Lenguaje}')";
                    return oDatos.Escribir(query);
                }
            }
            else
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    query = string.Format(" UPDATE Empleado SET Nombre='{0}', Apellido = '{1}', DNI = '{2}', Puesto='{3}',Salario='{4}',FechaIngreso='{5}',FechaEgreso='{6}',Antiguedad='{7}',Lenguaje_Programacion='{8}' where IdEmpleado='{9}'",
                        e.Nombre, e.Apellido, e.DNI, e.Puesto, e.Salario, e.FechaIngreso, e.FechaEgreso, e.Antiguedad, e.Lenguaje, e.Codigo);
                    return oDatos.Escribir(query);
                }
                else
                {
                    query = string.Format(" UPDATE Empleado SET Nombre='{0}', Apellido = '{1}', DNI = '{2}', Puesto='{3}',Salario='{4}',FechaIngreso='{5}',Antiguedad='{6}',Lenguaje_Programacion='{7}' where IdEmpleado='{8}'",
                                       e.Nombre, e.Apellido, e.DNI, e.Puesto, e.Salario, e.FechaIngreso, e.Antiguedad, e.Lenguaje, e.Codigo);
                    return oDatos.Escribir(query);
                }
            }
        }

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
                query = $"Insert into Empleado_Sucursal(IdEmpleado,IdSucursal) values ({empleado.Codigo},{sucursal.Codigo})";
                return oDatos.Escribir(query);
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
            tabla = oDatos.Leer("Select IdEmpleado,Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,FechaEgreso,Antiguedad,Lenguaje_Programacion from Empleado");
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