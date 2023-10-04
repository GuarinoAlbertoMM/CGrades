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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
