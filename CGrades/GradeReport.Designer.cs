namespace CGrades
{
    partial class GradeReport
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
            this.gradesreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gradeReportData = new CGrades.GradeReportData();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gradesreportTableAdapter = new CGrades.GradeReportDataTableAdapters.gradesreportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gradesreportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeReportData)).BeginInit();
            this.SuspendLayout();
            // 
            // gradesreportBindingSource
            // 
            this.gradesreportBindingSource.DataMember = "gradesreport";
            this.gradesreportBindingSource.DataSource = this.gradeReportData;
            // 
            // gradeReportData
            // 
            this.gradeReportData.DataSetName = "GradeReportData";
            this.gradeReportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.gradesreportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CGrades.GradesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.GradeReport_Load);
            // 
            // gradesreportTableAdapter
            // 
            this.gradesreportTableAdapter.ClearBeforeFill = true;
            // 
            // GradeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "GradeReport";
            this.Text = "GradeReport";
            this.Load += new System.EventHandler(this.GradeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradesreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeReportData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GradeReportData gradeReportData;
        private System.Windows.Forms.BindingSource gradesreportBindingSource;
        private GradeReportDataTableAdapters.gradesreportTableAdapter gradesreportTableAdapter;
    }
}