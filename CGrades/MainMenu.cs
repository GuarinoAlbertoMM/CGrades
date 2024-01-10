using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGrades
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {    
            Login login = new Login();

            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDB dbCreator = new CreateDB();
            dbCreator.DBCreation();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateDB dbCreator = new CreateDB();
            dbCreator.DeleteAllTables();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la ventana del reporte de maestros
            TeacherReport teacherReport = new TeacherReport();

            teacherReport.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la ventana del reporte de estudiantes
            StudentReport studentReport = new StudentReport();

            studentReport.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la ventana del reporte de calificaciones
            GradeReport gradeReport = new GradeReport();

            gradeReport.Show();
        }
    }
}
