using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGrades
{
    //Funcion para crear las tablas en la base de datos
    internal class CreateDB
    {

        string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";

        public bool CheckIfTablesExist()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME IN ('users', 'teachers', 'students', 'subjects', 'grades')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int tableCount = (int)command.ExecuteScalar();
                    return tableCount == 5; // Cambia el valor a la cantidad de tablas que necesitas verificar
                }
            }
        }

        public void DBCreation()
        {

            if (!CheckIfTablesExist())
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear la tabla "users"
                    string createUsersTableQuery = "CREATE TABLE users (" +
                                                   "id INT IDENTITY(1,1) PRIMARY KEY," +
                                                   "username NVARCHAR(50) NOT NULL," +
                                                   "password NVARCHAR(20) NOT NULL," +
                                                   "role INT)";

                    using (SqlCommand command = new SqlCommand(createUsersTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Crear la tabla "teachers"
                    string createTeachersTableQuery = "CREATE TABLE teachers (" +
                                                      "id INT IDENTITY(1,1) PRIMARY KEY," +
                                                      "user_id INT FOREIGN KEY REFERENCES users(id)," +
                                                      "fullname NVARCHAR(60) NOT NULL)";

                    using (SqlCommand command = new SqlCommand(createTeachersTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Crear la tabla "students"
                    string createStudentsTableQuery = "CREATE TABLE students (" +
                                                      "id INT IDENTITY(1,1) PRIMARY KEY," +
                                                      "user_id INT FOREIGN KEY REFERENCES users(id)," +
                                                      "fullname NVARCHAR(60) NOT NULL)";

                    using (SqlCommand command = new SqlCommand(createStudentsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Crear la tabla "subjects"
                    string createSubjectsTableQuery = "CREATE TABLE subjects (" +
                                                      "id INT IDENTITY(1,1) PRIMARY KEY," +
                                                      "subject_name NVARCHAR(30) NOT NULL)";

                    using (SqlCommand command = new SqlCommand(createSubjectsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Crear la tabla "grades"
                    string createGradesTableQuery = "CREATE TABLE grades (" +
                                                    "id INT IDENTITY(1,1) PRIMARY KEY," +
                                                    "subject_id INT FOREIGN KEY REFERENCES subjects(id)," +
                                                    "student_id INT FOREIGN KEY REFERENCES students(id)," +
                                                    "value INT)";

                    using (SqlCommand command = new SqlCommand(createGradesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Tablas creadas exitosamente.");
            }

            else
            {
                // Las tablas ya existen, no es necesario crearlas
                Console.WriteLine("Las tablas ya existen en la base de datos.");
            }
        }
    }
}
