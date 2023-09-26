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
using CGrades;

namespace CGrades
{
    public partial class Login : Form
    {
        int role = 0;

        AdminWT adminWT = new AdminWT();
        AdminWS adminWS = new AdminWS();
        TeacherWT teacherWT = new TeacherWT();
        TeacherWS teacherWS = new TeacherWS();
        StudentWS studentWS = new StudentWS();
        public Login()
        {
            InitializeComponent();
        }

        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=GUARI-PC\\SQLEXPRESS;Initial Catalog=CGrades;Integrated Security=True;";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public User VerifiedUser(string username, string password)
        {
            const string query = "SELECT * FROM users WHERE username = @Username AND password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);


                    var reader = command.ExecuteReader();
                    
                    reader.Read();
                    
                    User user = new User();

                    user.role = (int)reader["role"];

                    user.id = (int)reader["id"];

                    //User valort = (User)command.ExecuteScalar();

                    if (user != null )
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public class User
        {
            public int role { get; set; }

            public int id { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var result = VerifiedUser(textBox1.Text, textBox2.Text);


            if (result is null)
            {
                MessageBox.Show("Error: No existe el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            }

            if (result.role == 1)
            {
                adminWT.Visible = true;
            }

            if (result.role == 2)
            {
                teacherWT.Visible = true;
            }

            if (result.role == 3)
            {
                studentWS.Visible = true;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateDB dbCreator = new CreateDB();
            dbCreator.DBCreation();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
