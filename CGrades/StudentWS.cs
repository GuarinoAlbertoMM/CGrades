using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CGrades.Login;

namespace CGrades
{
    public partial class StudentWS : Form
    {
        private int userId;
        public StudentWS(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";

        //public class Student
        //{
        //    public int value { get; set; }

        //    public int id { get; set; }

        //    public string name { get; set; }

        //    public string subject { get; set; }
        //}
        //public List<Student> GetStudentGrades(int id)
        //{
        //    const string query = "SELECT std.fullname as [Name], g.[value] as Grade,s.subject_name as [Subject], s.id as Id " +
        //                         "FROM users u\r\n" +
        //                         "inner join grades g on u.id = g.student_id\r\n" +
        //                         "inner join subjects s on g.subject_id = s.id\r\n" +
        //                         "inner join students std on g.student_id = std.id\r\n" +
        //                         "where u.id = @ID";

        //    List<Student> students = new List<Student>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {

        //            command.Parameters.AddWithValue("@ID", id);

        //            var reader = command.ExecuteReader();

        //            reader.Read();

        //            while (reader.Read())
        //            {
        //                Student student = new Student();

        //                student.id = (int)reader["Id"];

        //                student.name = (string)reader["Name"];

        //                student.subject = (string)reader["Subject"];

        //                student.value = (int)reader["Value"];

        //                students.Add(student);

        //            }

        //        }
        //    }
        //    return students;
        //}

        public void DisplayTableData(int id)
        {
            try
            {
                // Consulta SQL para obtener datos de ambas tablas usando JOIN
                string query = $"SELECT s.fullname as [Name], g.[value] as Grade,SBJ.subject_name as [Subject], SBJ.id as Id FROM USERS U \r\nINNER JOIN students S ON U.ID = S.user_id\r\nINNER JOIN grades G ON S.id = G.student_id\r\nINNER JOIN subjects SBJ ON G.subject_id = SBJ.id\r\nwhere u.id = {id}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear un SqlDataAdapter para llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de ambas tablas
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como origen de datos del DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, muestra un mensaje en caso de error
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void closeStudentW(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void StudentLoad(object sender, EventArgs e)
        {
            DisplayTableData(userId);
        }
    }
}
