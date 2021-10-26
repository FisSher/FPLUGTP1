using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private readonly SqlConnection conexionSql = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());
        private SqlCommand sqlCommand;

        //Ya tiene stored
        public DataTable Leer(string Consulta_SQL, Hashtable hashdatos)
        {
            conexionSql.Open();
            DataTable tabla = new DataTable();
            sqlCommand = new SqlCommand(Consulta_SQL, conexionSql);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(sqlCommand);
                if ((hashdatos != null))
                {
                    foreach (string dato in hashdatos.Keys)
                    {
                        sqlCommand.Parameters.AddWithValue(dato, hashdatos[dato]);
                    }
                }
                DA.Fill(tabla);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conexionSql.Close(); }

            return tabla;
        }

        //Ya tiene stored
        public DataSet Leer2(string Consulta_SQL, Hashtable hashdatos)
        {
            conexionSql.Open();
            DataSet DS = new DataSet();
            sqlCommand = new SqlCommand(Consulta_SQL, conexionSql);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                if ((hashdatos != null))
                {
                    foreach (string dato in hashdatos.Keys)
                    {
                        sqlCommand.Parameters.AddWithValue(dato, hashdatos[dato]);
                    }
                }

                dataAdapter.Fill(DS);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conexionSql.Close(); }

            return DS;
        }

        //Ya tiene stored
        public bool Escribir(string Consulta_SQL, Hashtable hashdatos)
        {
            conexionSql.Open();
            SqlTransaction sqlTransaction;
            SqlCommand sqlCommand = new SqlCommand();
            sqlTransaction = conexionSql.BeginTransaction();

            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = conexionSql;
                sqlCommand.CommandText = Consulta_SQL;
                sqlCommand.Transaction = sqlTransaction;
                if ((hashdatos != null))
                {
                    foreach (string dato in hashdatos.Keys)
                    {
                        sqlCommand.Parameters.AddWithValue(dato, hashdatos[dato]);
                    }
                }
                sqlCommand.ExecuteNonQuery();
                sqlTransaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw ex;
            }
            finally
            { conexionSql.Close(); }
        }

        //Ya tiene stored
        public bool LeerEscalar(string consulta, Hashtable hashdatos)
        {
            conexionSql.Open();
            SqlCommand cmd = new SqlCommand(consulta, conexionSql);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if ((hashdatos != null))
                {
                    foreach (string dato in hashdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, hashdatos[dato]);
                    }
                }
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                conexionSql.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException sqlex)
            { throw sqlex; }
            catch (Exception)
            {
                throw;
            }
        }
    }
}