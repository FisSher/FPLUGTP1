using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        //private readonly SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());

        private readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FPLUG;Integrated Security=True");

        //Voy a ver si le doy uso, de ultima lo borro
        public string PruebaConexion()
        {
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                return "Conexion ok";
            }
            else
            {
                return "No se pudo conectar a la base";
            }
        }

        //Traigo una lectura de tabla generica
        public DataTable Leer(string Consulta_SQL)
        {
            DataTable tabla = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Consulta_SQL, sqlConnection);
                dataAdapter.Fill(tabla);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }

            return tabla;
        }

        public DataSet Leer2(string Consulta_SQL)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Consulta_SQL, sqlConnection);
                dataAdapter.Fill(dataSet);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }

            return dataSet;
        }

        //Tengo que hacer acá el transaction
        public bool Escribir(string Consulta_SQL)
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction;
            SqlCommand sqlCommand = new SqlCommand();
            sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
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
            { sqlConnection.Close(); }
        }

        //Tengo que leer escalar para el tema base
        public bool LeerEscalar(string consulta)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(consulta, sqlConnection);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException)
            { throw; }
        }
    }
}