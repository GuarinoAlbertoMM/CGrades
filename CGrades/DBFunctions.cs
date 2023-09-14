using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CGrades
{
    public static class DBFunctions
    {
        private static string connectionString = "Data Source =GUARI-PC\\SQLEXPRESS; Initial Catalog = Clientes ;Integrated Security=true"; // Reemplaza con tu cadena de conexión

        //Conexion a la base de datos
        public static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                return null;
            }
        }
        //Cierra conexion a la base de datos
        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        
    }
}
