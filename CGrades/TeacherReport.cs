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
    public partial class TeacherReport : Form
    {
        public TeacherReport()
        {
            InitializeComponent();
        }

        private void TeacherReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'teacherReportData.teachersreport' table. You can move, or remove it, as needed.
            this.teachersreportTableAdapter.Fill(this.teacherReportData.teachersreport);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
