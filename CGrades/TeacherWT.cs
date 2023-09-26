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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CGrades
{
    public partial class TeacherWT : Form
    {
        public TeacherWT()
        {
            InitializeComponent();
        }

        private void closeTeacherWT(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";
        private int selectedGradeId = -1;

        public void DisplayTableData()
        {
            try
            {
                // Consulta SQL para obtener los datos de las tablas relacionadas
                string query = @"
                        SELECT
                            g.id,
                            g.subject_id,
                            g.student_id,
                            g.value,
                            s.fullname AS student_fullname,
                            sub.subject_name
                        FROM
                            grades g
                        INNER JOIN
                            students s ON g.student_id = s.id
                        INNER JOIN
                            subjects sub ON g.subject_id = sub.id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear un SqlDataAdapter para llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos combinados
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como origen de datos del DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GradesLoad(object sender, EventArgs e)
        {
            // Deshabilitar los TextBox
            textBox1.Enabled = false;   //id de estudiante
            textBox2.Enabled = false;   //id de asignatura
            textBox3.Enabled = false;   //calificacion

            // Limpiar los TextBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            DisplayTableData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Habilita los TextBox para ingresar datos
            textBox1.Enabled = true;    //id de estudiante
            textBox2.Enabled = true;    //id de asignatura
            textBox3.Enabled = true;    //calificacion

            // Limpia los TextBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se está editando un registro existente o creando uno nuevo
                if (selectedGradeId != -1)
                {
                    // Estás editando un registro existente, por lo que debes realizar una actualización en lugar de una inserción

                    // Obtener los nuevos valores de los TextBox
                    string nuevoIdEst = textBox1.Text;
                    string nuevaIdAsig= textBox2.Text;
                    string nuevaNota = textBox3.Text;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Consulta SQL para actualizar los datos del usuario
                        string updateQuery = "UPDATE grades SET subject_id = @SubjectID, student_id = @StudentID, value = @Value WHERE id = @ID";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SubjectID", nuevaIdAsig);
                            command.Parameters.AddWithValue("@StudentID", nuevoIdEst);
                            command.Parameters.AddWithValue("@Value", nuevaNota);
                            command.Parameters.AddWithValue("@ID", selectedGradeId);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Datos actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar y deshabilitar los TextBox después de guardar
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;

                    // Reiniciar la variable selectedUserId
                    selectedGradeId = -1;

                    // Actualizar la vista de datos en el DataGridView
                    DisplayTableData();
                }
                else
                {
                    // Estás creando un nuevo registro, realiza la inserción en lugar de la actualización
                    // Implementa la lógica para insertar un nuevo registro en la base de datos
                    // Luego, limpia y deshabilita los TextBox y actualiza la vista de datos en el DataGridView

                    try
                    {
                        // Insertar un nuevo usuario en la tabla "grades"
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Consulta SQL para insertar un nuevo usuario
                            string insertUserQuery = "INSERT INTO grades (subject_id, student_id, value) VALUES (@SubjectID, @StudentID, @Value); SELECT SCOPE_IDENTITY();";

                            using (SqlCommand command = new SqlCommand(insertUserQuery, connection))
                            {
                                // Pasar los valores de TextBox como parámetros
                                command.Parameters.AddWithValue("@SubjectID", textBox2.Text);
                                command.Parameters.AddWithValue("@StudentID", textBox1.Text);
                                command.Parameters.AddWithValue("@Value", textBox3.Text);

                                // Obtener el ID generado automáticamente
                                int userId = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }

                        // Deshabilitar los TextBox después de guardar
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;

                        // Limpiar los TextBox
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();

                        DisplayTableData();

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

        private void button2_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado desde la fila seleccionada
                selectedGradeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column2"].Value);

                // Cargar los valores del usuario en los TextBox para editar
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["IdEstd"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["Calificacion"].Value.ToString();

                // Habilitar los TextBox para editar
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un registro para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                            string deleteTeacherQuery = "DELETE FROM grades WHERE id = @ID";

                            using (SqlCommand teacherCommand = new SqlCommand(deleteTeacherQuery, connection))
                            {
                                teacherCommand.Parameters.AddWithValue("@ID", selectedUserId);
                                teacherCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Registro eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualizar la vista de datos en el DataGridView después de eliminar
                            DisplayTableData();
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
