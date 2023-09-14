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
        StudentWS studentWS = new StudentWS();
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public int userId()
        {
            int sqlId = 1;

            return sqlId;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            role = userId();

            if (role == 1)
            {
                adminWT.Visible = true;
            }
            if (role == 2)
            {
                teacherWT.Visible = true;
            }
            if (role == 3)
            {
                studentWS.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateDB dbCreator = new CreateDB();
            dbCreator.DBCreation();
        }
    }
}
