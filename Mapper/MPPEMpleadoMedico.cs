using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using DAL;

namespace Mapper
{
    public class MPPEmpleadoMedico : IGestor<BEEmpleadoMedico>
    {

        public MPPEmpleadoMedico()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;
        public bool Baja(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleadoMedico e)
        {
            string query = $"UPDATE Empleado SET Baja=1, FechaEgreso = '{DateTime.Now.ToShortDateString()}' where IdEmpleado='{e.Codigo}'";
            return oDatos.Escribir(query);
        }



        public bool Guardar(BEEmpleadoMedico e)
        {
            string query;
            if (e.Codigo == 0)
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    query = $"Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad,FechaEgreso) values ('{e.Nombre}','{e.Apellido}','{e.DNI}','{e.Puesto}','{e.Salario}','{e.Baja}','{e.FechaIngreso}','{e.Antiguedad}','{e.FechaEgreso}')";
                    return oDatos.Escribir(query);
                }
                else
                {
                    query = $"Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad) values ('{e.Nombre}','{e.Apellido}','{e.DNI}','{e.Puesto}','{e.Salario}','{e.Baja}','{e.FechaIngreso}','{e.Antiguedad}')";
                    return oDatos.Escribir(query);
                }
            }
            else
            {
                if (e.FechaEgreso > e.FechaIngreso)
                {
                    query = string.Format(" UPDATE Empleado SET Nombre='{0}', Apellido = '{1}', DNI = '{2}', Puesto='{3}',Salario='{4}',FechaIngreso='{5}',FechaEgreso='{6}',Antiguedad='{7}' where IdEmpleado='{8}'",
                        e.Nombre, e.Apellido, e.DNI, e.Puesto, e.Salario, e.FechaIngreso, e.FechaEgreso, e.Antiguedad, e.Codigo);
                    return oDatos.Escribir(query);
                }
                else
                {
                    query = string.Format(" UPDATE Empleado SET Nombre='{0}', Apellido = '{1}', DNI = '{2}', Puesto='{3}',Salario='{4}',FechaIngreso='{5}',Antiguedad='{6}' where IdEmpleado='{7}'",
                                       e.Nombre, e.Apellido, e.DNI, e.Puesto, e.Salario, e.FechaIngreso, e.Antiguedad, e.Codigo);
                    return oDatos.Escribir(query);
                }
            }
        }

        public bool GuardarEnSucursal(BESucursal sucursal, BEEmpleadoMedico empleado)
        {
            string query;
            BEEmpleadoMedico empleadoBuscado = new BEEmpleadoMedico();
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

        public BEEmpleadoMedico ListarObjeto(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEmpleadoMedico> ListarTodo()
        {
            DataTable tabla;
            oDatos = new Acceso();
            tabla = oDatos.Leer("Select IdEmpleado,Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,FechaEgreso,Antiguedad,Lenguaje_Programacion from Empleado");
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
