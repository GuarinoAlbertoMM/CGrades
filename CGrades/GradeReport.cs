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
    public partial class GradeReport : Form
    {
        public GradeReport()
        {
            InitializeComponent();
        }

        private void GradeReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gradeReportData.gradesreport' table. You can move, or remove it, as needed.
            this.gradesreportTableAdapter.Fill(this.gradeReportData.gradesreport);

            this.reportViewer1.RefreshReport();
        }
    }
}
