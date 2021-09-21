using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private readonly SqlConnection conexionSql = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());

        //Traigo una lectura de tabla generica
        public DataTable Leer(string Consulta_SQL)
        {
            DataTable tabla = new DataTable();
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(Consulta_SQL, conexionSql);
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

        public DataSet Leer2(string Consulta_SQL)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Consulta_SQL, conexionSql);
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

        //Tengo que hacer acá el transaction
        public bool Escribir(string Consulta_SQL)
        {
            conexionSql.Open();
            SqlTransaction sqlTransaction;
            SqlCommand sqlCommand = new SqlCommand();
            sqlTransaction = conexionSql.BeginTransaction();

            try
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = conexionSql;
                sqlCommand.CommandText = Consulta_SQL;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery(); //Ejecuta->
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

        public bool LeerEscalar(string consulta)
        {
            conexionSql.Open();
            SqlCommand cmd = new SqlCommand(consulta, conexionSql);
            cmd.CommandType = CommandType.Text;
            try
            {
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