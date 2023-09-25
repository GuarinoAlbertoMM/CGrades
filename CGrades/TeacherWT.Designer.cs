namespace CGrades
{
    partial class TeacherWT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherWT));
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdEstd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearEstudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(111, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 53);
            this.label5.TabIndex = 12;
            this.label5.Text = "Calificaciones";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(629, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 38);
            this.button3.TabIndex = 25;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(364, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 38);
            this.button2.TabIndex = 24;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(120, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 23;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(629, 157);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(210, 34);
            this.textBox3.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(623, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Calificación";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(364, 157);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 34);
            this.textBox2.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 34);
            this.textBox1.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEstd,
            this.Nombre,
            this.Asig,
            this.Calificacion});
            this.dataGridView1.Location = new System.Drawing.Point(120, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(992, 490);
            this.dataGridView1.TabIndex = 17;
            // 
            // IdEstd
            // 
            this.IdEstd.HeaderText = "Id de estudiante";
            this.IdEstd.MinimumWidth = 6;
            this.IdEstd.Name = "IdEstd";
            this.IdEstd.ReadOnly = true;
            this.IdEstd.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 210;
            // 
            // Asig
            // 
            this.Asig.HeaderText = "Asignatura";
            this.Asig.MinimumWidth = 6;
            this.Asig.Name = "Asig";
            this.Asig.ReadOnly = true;
            this.Asig.Width = 260;
            // 
            // Calificacion
            // 
            this.Calificacion.HeaderText = "Calificación";
            this.Calificacion.MinimumWidth = 6;
            this.Calificacion.Name = "Calificacion";
            this.Calificacion.ReadOnly = true;
            this.Calificacion.Width = 210;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(358, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 32);
            this.label2.TabIndex = 15;
            this.label2.Text = "Id de asignatura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(114, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Id de estudiante";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.tablasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1222, 30);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(89, 26);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // tablasToolStripMenuItem
            // 
            this.tablasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearEstudiantesToolStripMenuItem});
            this.tablasToolStripMenuItem.Name = "tablasToolStripMenuItem";
            this.tablasToolStripMenuItem.Size = new System.Drawing.Size(77, 26);
            this.tablasToolStripMenuItem.Text = "Tablas";
            this.tablasToolStripMenuItem.Click += new System.EventHandler(this.tablasToolStripMenuItem_Click);
            // 
            // crearEstudiantesToolStripMenuItem
            // 
            this.crearEstudiantesToolStripMenuItem.Name = "crearEstudiantesToolStripMenuItem";
            this.crearEstudiantesToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.crearEstudiantesToolStripMenuItem.Text = "Crear asignaturas";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DimGray;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(924, 210);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 38);
            this.button4.TabIndex = 27;
            this.button4.Text = "Nuevo";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // TeacherWT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1222, 790);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TeacherWT";
            this.Text = "TeacherWT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closeTeacherWT);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calificacion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearEstudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button button4;
    }
}