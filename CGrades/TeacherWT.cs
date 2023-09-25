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

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
