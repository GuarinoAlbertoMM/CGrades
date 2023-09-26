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
    public partial class TeacherWS : Form
    {
        public TeacherWS()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";
        private int selectedSubId = -1;

        public void DisplayTableData()
        {
            try
            {
                // Consulta SQL para obtener todos los valores de la tabla "subjects"
                string query = "SELECT * FROM subjects";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear un SqlDataAdapter para llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la tabla "subjects"
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

        private void button4_Click(object sender, EventArgs e)
        {
            // Habilita los TextBox para ingresar datos
            textBox2.Enabled = true;

            // Limpia los TextBox
            textBox2.Clear();
        }



        private void subjectLoad(object sender, EventArgs e)
        {
            // Deshabilitar los TextBox
            textBox2.Enabled = false;   //nombre de asignatura

            // Limpiar los TextBox
            textBox2.Clear();

            DisplayTableData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se está editando un registro existente o creando uno nuevo
                if (selectedSubId != -1)
                {
                    // Estás editando un registro existente, por lo que debes realizar una actualización en lugar de una inserción

                    // Obtener los nuevos valores de los TextBox
                    string nuevaAsignatura = textBox2.Text;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Consulta SQL para actualizar los datos del usuario
                        string updateQuery = "UPDATE subjects SET subject_name = @SubjectName WHERE id = @ID";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SubjectName", nuevaAsignatura);
                            command.Parameters.AddWithValue("@ID", selectedSubId);

                            command.ExecuteNonQuery();
                        }

                    }

                    MessageBox.Show("Datos actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar y deshabilitar los TextBox después de guardar
                    textBox2.Clear();

                    textBox2.Enabled = false;

                    // Reiniciar la variable selectedUserId
                    selectedSubId = -1;

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
                        // Insertar un nuevo usuario en la tabla "subjects"
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Consulta SQL para insertar una nuevas asignatura
                            string insertSubjectQuery = "INSERT INTO subjects (subject_name) VALUES (@SubjectName); SELECT SCOPE_IDENTITY();";

                            using (SqlCommand command = new SqlCommand(insertSubjectQuery, connection))
                            {
                                // Pasar los valores de TextBox como parámetros
                                command.Parameters.AddWithValue("@SubjectName", textBox2.Text);

                                // Obtener el ID generado automáticamente
                                int userId = Convert.ToInt32(command.ExecuteScalar());

                            }
                        }

                        // Deshabilitar los TextBox después de guardar
                        textBox2.Enabled = false;   //nombre de asignatura

                        // Limpiar los TextBox
                        textBox2.Clear();

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
                selectedSubId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value);

                // Cargar los valores del usuario en los TextBox para editar
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Column2"].Value.ToString();

                // Habilitar los TextBox para editar
                textBox2.Enabled = true;
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
                        int selectedSubjectId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value);

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Consulta SQL para eliminar el registro de la tabla "teachers"
                            string deleteTeacherQuery = "DELETE FROM subjects WHERE id = @ID";

                            using (SqlCommand teacherCommand = new SqlCommand(deleteTeacherQuery, connection))
                            {
                                teacherCommand.Parameters.AddWithValue("@ID", selectedSubjectId);
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
