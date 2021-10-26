using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{//Listo para los SP
    public class MPPEmpleado : IGestor<BEEmpleado>
    {
        public MPPEmpleado()
        {
            oDatos = new Acceso();
        }

        public List<BEEmpleado> ListarTodo()
        {
            List<BEEmpleado> ListaEmpleados = new List<BEEmpleado>();
            //SP: S_Empleado_ListarTodo
            string query = "S_Empleado_ListarTodo";

            DataTable tabla = oDatos.Leer(query,null);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    if (fila["Lenguaje"] is DBNull)
                    {
                        BEEmpleadoMedico empleadoM = new BEEmpleadoMedico();
                        empleadoM.Nombre = fila["Nombre"].ToString();
                        empleadoM.Apellido = fila["Apellido"].ToString();
                        empleadoM.DNI = Convert.ToInt32(fila["DNI"]);
                        empleadoM.Puesto = Convert.ToInt32(fila["Puesto"]);
                        empleadoM.Salario = Convert.ToDouble(fila["Salario"]);
                        empleadoM.Baja = Convert.ToInt32(fila["Baja"]);
                        if (empleadoM.Baja == 1)
                            empleadoM.FechaEgreso = Convert.ToDateTime(fila["FechaEgreso"]);
                        empleadoM.FechaIngreso = Convert.ToDateTime(fila["FechaIngreso"]);
                        empleadoM.Antiguedad = Convert.ToInt32(fila["Antiguedad"]);
                        ListaEmpleados.Add(empleadoM);
                    }
                    else
                    {
                        BEEmpleadoIT empleadoIT = new BEEmpleadoIT();
                        empleadoIT.Nombre = fila["Nombre"].ToString();
                        empleadoIT.Apellido = fila["Apellido"].ToString();
                        empleadoIT.DNI = Convert.ToInt32(fila["DNI"]);
                        empleadoIT.Puesto = Convert.ToInt32(fila["Puesto"]);
                        empleadoIT.Salario = Convert.ToDouble(fila["Salario"]);
                        empleadoIT.Baja = Convert.ToInt32(fila["Baja"]);
                        if (empleadoIT.Baja == 1)
                            empleadoIT.FechaEgreso = Convert.ToDateTime(fila["FechaEgreso"]);
                        empleadoIT.FechaIngreso = Convert.ToDateTime(fila["FechaIngreso"]);
                        empleadoIT.Antiguedad = Convert.ToInt32(fila["Antiguedad"]);
                        empleadoIT.Lenguaje = fila["Lenguaje_Programacion"].ToString();
                        ListaEmpleados.Add(empleadoIT);
                    }
                    return ListaEmpleados;
                }
            }

            return null;
        }

        #region unused

        private Acceso oDatos;

        public bool Baja(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }

        public BEEmpleado ListarObjeto(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }
    }

    #endregion unused
}