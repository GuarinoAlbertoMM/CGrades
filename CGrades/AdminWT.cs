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
    public partial class AdminWT : Form
    {   
        public AdminWT()
        {
            InitializeComponent();
        }
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";
        private int selectedUserId = -1;

        public void DisplayTableData(string tableName)
        {
            try
            {
                // Consulta SQL para obtener datos de ambas tablas usando JOIN
                string query = "SELECT users.id, users.username, users.password, teachers.user_id, teachers.fullname " +
                               "FROM users " +
                               "INNER JOIN teachers ON users.id = teachers.user_id";

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

        private void closeAdminWT(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado desde la fila seleccionada
                selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value);

                // Cargar los valores del usuario en los TextBox para editar
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["Column5"].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells["Column3"].Value.ToString();

                // Habilitar los TextBox para editar
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un registro para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tablaDeEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void AdminWT_Load(object sender, EventArgs e)
        {
            DisplayTableData("teachers");
        }

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Verificar si se está editando un registro existente o creando uno nuevo
                if (selectedUserId != -1)
                {
                    // Estás editando un registro existente, por lo que debes realizar una actualización en lugar de una inserción

                    // Obtener los nuevos valores de los TextBox
                    string nuevoUsuario = textBox2.Text;
                    string nuevaContraseña = textBox3.Text;
                    string nuevoNombre = textBox4.Text;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Consulta SQL para actualizar los datos del usuario
                        string updateQuery = "UPDATE users SET username = @Username, password = @Password WHERE id = @UserID";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Username", nuevoUsuario);
                            command.Parameters.AddWithValue("@Password", nuevaContraseña);
                            command.Parameters.AddWithValue("@UserID", selectedUserId);

                            command.ExecuteNonQuery();
                        }

                        // Consulta SQL para actualizar el nombre del profesor en la tabla "teachers"
                        string updateTeacherQuery = "UPDATE teachers SET fullname = @Fullname WHERE user_id = @UserID";

                        using (SqlCommand teacherCommand = new SqlCommand(updateTeacherQuery, connection))
                        {
                            teacherCommand.Parameters.AddWithValue("@Fullname", nuevoNombre);
                            teacherCommand.Parameters.AddWithValue("@UserID", selectedUserId);

                            teacherCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Datos actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar y deshabilitar los TextBox después de guardar
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;

                    // Reiniciar la variable selectedUserId
                    selectedUserId = -1;

                    // Actualizar la vista de datos en el DataGridView
                    DisplayTableData("teachers");
                }
                else
                {
                    // Estás creando un nuevo registro, realiza la inserción en lugar de la actualización
                    // Implementa la lógica para insertar un nuevo registro en la base de datos
                    // Luego, limpia y deshabilita los TextBox y actualiza la vista de datos en el DataGridView

                    try
                    {
                        // Insertar un nuevo usuario en la tabla "users"
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Consulta SQL para insertar un nuevo usuario
                            string insertUserQuery = "INSERT INTO users (username, password, role) VALUES (@Username, @Password, 2); SELECT SCOPE_IDENTITY();";

                            using (SqlCommand command = new SqlCommand(insertUserQuery, connection))
                            {
                                // Pasar los valores de TextBox como parámetros
                                command.Parameters.AddWithValue("@Username", textBox2.Text);
                                command.Parameters.AddWithValue("@Password", textBox3.Text);

                                // Obtener el ID generado automáticamente
                                int userId = Convert.ToInt32(command.ExecuteScalar());

                                // Insertar el nombre del profesor en la tabla "teachers" con el ID de usuario
                                string insertTeacherQuery = "INSERT INTO teachers (user_id, fullname) VALUES (@UserId, @Fullname);";

                                using (SqlCommand teacherCommand = new SqlCommand(insertTeacherQuery, connection))
                                {
                                    teacherCommand.Parameters.AddWithValue("@UserId", userId);
                                    teacherCommand.Parameters.AddWithValue("@Fullname", textBox4.Text);

                                    // Ejecutar la inserción del profesor
                                    teacherCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // Deshabilitar los TextBox después de guardar
                        textBox2.Enabled = false;   //usuario
                        textBox3.Enabled = false;   //contra
                        textBox4.Enabled = false;   //nombre

                        // Limpiar los TextBox
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                        DisplayTableData("teachers");

                        MessageBox.Show("Datos guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores, muestra un mensaje en caso de error
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, muestra un mensaje en caso de error
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Habilita los TextBox para ingresar datos
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            // Limpia los TextBox
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado una fila en el DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Mostrar un cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verificar la respuesta del usuario
                    if (result == DialogResult.Yes)
                    {
                        // Obtener el ID del usuario seleccionado desde la fila seleccionada
                        int selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column2"].Value);

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Consulta SQL para eliminar el registro de la tabla "teachers"
                            string deleteTeacherQuery = "DELETE FROM teachers WHERE user_id = @UserID";

                            using (SqlCommand teacherCommand = new SqlCommand(deleteTeacherQuery, connection))
                            {
                                teacherCommand.Parameters.AddWithValue("@UserID", selectedUserId);
                                teacherCommand.ExecuteNonQuery();
                            }

                            // Consulta SQL para eliminar el registro de la tabla "users"
                            string deleteUserQuery = "DELETE FROM users WHERE id = @UserID";

                            using (SqlCommand userCommand = new SqlCommand(deleteUserQuery, connection))
                            {
                                userCommand.Parameters.AddWithValue("@UserID", selectedUserId);
                                userCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Registro eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar la vista de datos en el DataGridView después de eliminar
                            DisplayTableData("teachers");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, muestra un mensaje en caso de error
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
