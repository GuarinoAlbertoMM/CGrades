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
            // Crear una instancia de la segunda ventana (form)
            Login login = new Login(); // Reemplaza 'SegundaVentana' con el nombre de tu formulario

            // Mostrar la segunda ventana
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
            // Crear una instancia de la segunda ventana (form)
            TeacherReport teacherReport = new TeacherReport(); // Reemplaza 'SegundaVentana' con el nombre de tu formulario

            // Mostrar la segunda ventana
            teacherReport.Show();
        }
    }
}
