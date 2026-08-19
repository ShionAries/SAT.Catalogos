namespace Tester.Forms {
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
            this.InformacionBox = new System.Windows.Forms.GroupBox();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.GridData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.InformacionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            this.SuspendLayout();
            // 
            // cboRepositorio
            // 
            this.cboRepositorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRepositorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepositorio.FormattingEnabled = true;
            this.cboRepositorio.Location = new System.Drawing.Point(78, 12);
            this.cboRepositorio.Name = "cboRepositorio";
            this.cboRepositorio.Size = new System.Drawing.Size(625, 21);
            this.cboRepositorio.TabIndex = 4;
            // 
            // Originlabel
            // 
            this.Originlabel.AutoSize = true;
            this.Originlabel.Location = new System.Drawing.Point(9, 16);
            this.Originlabel.Name = "Originlabel";
            this.Originlabel.Size = new System.Drawing.Size(63, 13);
            this.Originlabel.TabIndex = 3;
            this.Originlabel.Text = "Repositorio:";
            // 
            // Cargar
            // 
            this.Cargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cargar.Location = new System.Drawing.Point(709, 11);
            this.Cargar.Name = "Cargar";
            this.Cargar.Size = new System.Drawing.Size(75, 23);
            this.Cargar.TabIndex = 5;
            this.Cargar.Text = "Cargar";
            this.Cargar.UseVisualStyleBackColor = true;
            this.Cargar.Click += new System.EventHandler(this.Cargar_Click);
            // 
            // InformacionBox
            // 
            this.InformacionBox.Controls.Add(this.label1);
            this.InformacionBox.Controls.Add(this.DescripcionLabel);
            this.InformacionBox.Controls.Add(this.cboRepositorio);
            this.InformacionBox.Controls.Add(this.Cargar);
            this.InformacionBox.Controls.Add(this.Originlabel);
            this.InformacionBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InformacionBox.Location = new System.Drawing.Point(5, 5);
            this.InformacionBox.Name = "InformacionBox";
            this.InformacionBox.Size = new System.Drawing.Size(790, 70);
            this.InformacionBox.TabIndex = 7;
            this.InformacionBox.TabStop = false;
            this.InformacionBox.Text = "Información";
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.AutoSize = true;
            this.DescripcionLabel.Location = new System.Drawing.Point(9, 46);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescripcionLabel.TabIndex = 0;
            this.DescripcionLabel.Text = "Descripción";
            // 
            // GridData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.GridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridData.Location = new System.Drawing.Point(5, 75);
            this.GridData.Name = "GridData";
            this.GridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.GridData.RowHeadersVisible = false;
            this.GridData.Size = new System.Drawing.Size(790, 370);
            this.GridData.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // RepositoryTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridData);
            this.Controls.Add(this.InformacionBox);
            this.Name = "RepositoryTestForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "RepositoryTestForm";
            this.Load += new System.EventHandler(this.RepositoryTestForm_Load);
            this.InformacionBox.ResumeLayout(false);
            this.InformacionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRepositorio;
        private System.Windows.Forms.Label Originlabel;
        private System.Windows.Forms.Button Cargar;
        private System.Windows.Forms.GroupBox InformacionBox;
        private System.Windows.Forms.Label DescripcionLabel;
        private System.Windows.Forms.DataGridView GridData;
        private System.Windows.Forms.Label label1;
    }
}