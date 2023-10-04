using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                MessageBox.Show("Las tablas ya existen en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteAllTables()
        {
            // Cadena de conexión a la base de datos (asegúrate de que sea la base de datos correcta)
            string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";

            // Lista de nombres de tablas a eliminar
            string[] tableNames = { "grades", "students", "subjects", "teachers", "users" }; // Agrega aquí el nombre de todas las tablas que deseas eliminar

            // Preguntar al usuario si realmente desea eliminar las tablas
            DialogResult confirmResult = MessageBox.Show("¿Seguro que quieres eliminar todas las tablas de la base de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (string tableName in tableNames)
                    {
                        // Consulta SQL para eliminar la tabla
                        string dropTableQuery = $"DROP TABLE IF EXISTS {tableName}";

                        using (SqlCommand command = new SqlCommand(dropTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Tabla {tableName} eliminada.");
                    }

                    Console.WriteLine("Todas las tablas han sido eliminadas.");

                    // Mostrar un mensaje de información después de eliminar las tablas
                    MessageBox.Show("Todas las tablas han sido eliminadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // El usuario eligió no eliminar las tablas
                MessageBox.Show("Operación cancelada. No se eliminaron las tablas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
