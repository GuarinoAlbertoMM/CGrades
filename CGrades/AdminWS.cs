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

namespace CGrades
{
    public partial class AdminWS : Form
    {
        public AdminWS()
        {
            InitializeComponent();
        }

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void DisplayTableData(string tableName)
        {
            try
            {
                // Cadena de conexión a la base de datos
                string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";

                // Consulta SQL para seleccionar todos los datos de la tabla especificada
                string query = $"SELECT * FROM {tableName}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Enlaza los datos al DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, muestra un mensaje en caso de error
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeAdminWS(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void AdminWS_Load(object sender, EventArgs e)
        {
            DisplayTableData("students");
        }
    }
}
