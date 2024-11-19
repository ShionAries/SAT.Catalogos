namespace Tester {
    partial class RepositoryTestForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboRepositorio = new System.Windows.Forms.ComboBox();
            this.Originlabel = new System.Windows.Forms.Label();
            this.Cargar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GridData = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            this.SuspendLayout();
            // 
            // cboRepositorio
            // 
            this.cboRepositorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepositorio.FormattingEnabled = true;
            this.cboRepositorio.Location = new System.Drawing.Point(87, 22);
            this.cboRepositorio.Name = "cboRepositorio";
            this.cboRepositorio.Size = new System.Drawing.Size(253, 21);
            this.cboRepositorio.TabIndex = 4;
            // 
            // Originlabel
            // 
            this.Originlabel.AutoSize = true;
            this.Originlabel.Location = new System.Drawing.Point(18, 26);
            this.Originlabel.Name = "Originlabel";
            this.Originlabel.Size = new System.Drawing.Size(63, 13);
            this.Originlabel.TabIndex = 3;
            this.Originlabel.Text = "Repositorio:";
            // 
            // Cargar
            // 
            this.Cargar.Location = new System.Drawing.Point(346, 21);
            this.Cargar.Name = "Cargar";
            this.Cargar.Size = new System.Drawing.Size(75, 23);
            this.Cargar.TabIndex = 5;
            this.Cargar.Text = "Cargar";
            this.Cargar.UseVisualStyleBackColor = true;
            this.Cargar.Click += new System.EventHandler(this.Cargar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboRepositorio);
            this.groupBox1.Controls.Add(this.Cargar);
            this.groupBox1.Controls.Add(this.Originlabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // GridData
            // 
            this.GridData.AllowUserToAddRows = false;
            this.GridData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.GridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridData.Location = new System.Drawing.Point(0, 70);
            this.GridData.Name = "GridData";
            this.GridData.ReadOnly = true;
            this.GridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.GridData.RowHeadersVisible = false;
            this.GridData.Size = new System.Drawing.Size(800, 380);
            this.GridData.TabIndex = 8;
            // 
            // RepositoryTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridData);
            this.Controls.Add(this.groupBox1);
            this.Name = "RepositoryTestForm";
            this.Text = "RepositoryTestForm";
            this.Load += new System.EventHandler(this.RepositoryTestForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRepositorio;
        private System.Windows.Forms.Label Originlabel;
        private System.Windows.Forms.Button Cargar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GridData;
    }
}