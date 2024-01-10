namespace CGrades
{
    partial class StudentReport
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
            this.studentReportData = new CGrades.StudentReportData();
            this.studentReportDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsreportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.studentsreportTableAdapter = new CGrades.StudentReportDataTableAdapters.studentsreportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.studentReportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentReportDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsreportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsreportBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.studentsreportBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CGrades.StudentsReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.StudentReport_Load);
            // 
            // studentReportData
            // 
            this.studentReportData.DataSetName = "StudentReportData";
            this.studentReportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentReportDataBindingSource
            // 
            this.studentReportDataBindingSource.DataSource = this.studentReportData;
            this.studentReportDataBindingSource.Position = 0;
            // 
            // studentsreportBindingSource
            // 
            this.studentsreportBindingSource.DataMember = "studentsreport";
            this.studentsreportBindingSource.DataSource = this.studentReportData;
            // 
            // studentsreportBindingSource1
            // 
            this.studentsreportBindingSource1.DataMember = "studentsreport";
            this.studentsreportBindingSource1.DataSource = this.studentReportData;
            // 
            // studentsreportTableAdapter
            // 
            this.studentsreportTableAdapter.ClearBeforeFill = true;
            // 
            // StudentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "StudentReport";
            this.Text = "StudentReport";
            this.Load += new System.EventHandler(this.StudentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentReportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentReportDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsreportBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource studentReportDataBindingSource;
        private StudentReportData studentReportData;
        private System.Windows.Forms.BindingSource studentsreportBindingSource;
        private System.Windows.Forms.BindingSource studentsreportBindingSource1;
        private StudentReportDataTableAdapters.studentsreportTableAdapter studentsreportTableAdapter;
    }
}