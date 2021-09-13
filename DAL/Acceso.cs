using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());

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

        public bool Escribir(string Consulta_SQL)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            cmd.CommandText = Consulta_SQL;
            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                throw;
            }

            finally
            { sqlConnection.Close(); }
        }

        //Todavia no se si quiero leer escalar, no creo


    }
}