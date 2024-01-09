namespace CGrades
{
    partial class TeacherReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.teacherReportData = new CGrades.TeacherReportData();
            this.teachersreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teachersreportTableAdapter = new CGrades.TeacherReportDataTableAdapters.teachersreportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.teacherReportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersreportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.teachersreportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CGrades.TeachersReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // teacherReportData
            // 
            this.teacherReportData.DataSetName = "TeacherReportData";
            this.teacherReportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // teachersreportBindingSource
            // 
            this.teachersreportBindingSource.DataMember = "teachersreport";
            this.teachersreportBindingSource.DataSource = this.teacherReportData;
            // 
            // teachersreportTableAdapter
            // 
            this.teachersreportTableAdapter.ClearBeforeFill = true;
            // 
            // TeacherReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TeacherReport";
            this.Text = "TeacherReport";
            this.Load += new System.EventHandler(this.TeacherReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teacherReportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersreportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TeacherReportData teacherReportData;
        private System.Windows.Forms.BindingSource teachersreportBindingSource;
        private TeacherReportDataTableAdapters.teachersreportTableAdapter teachersreportTableAdapter;
    }
}