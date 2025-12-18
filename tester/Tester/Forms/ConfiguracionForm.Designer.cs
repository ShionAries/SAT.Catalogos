namespace Tester.Forms {
    partial class ConfiguracionForm {
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
            this.LabelFileName = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WorkingFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TemporaryFolder = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Header = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelFileName
            // 
            this.LabelFileName.AutoSize = true;
            this.LabelFileName.Location = new System.Drawing.Point(13, 23);
            this.LabelFileName.Name = "LabelFileName";
            this.LabelFileName.Size = new System.Drawing.Size(207, 13);
            this.LabelFileName.TabIndex = 0;
            this.LabelFileName.Text = "Nombre del archivo de control de origenes";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(16, 39);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(271, 20);
            this.FileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del archivo log";
            // 
            // LogFileName
            // 
            this.LogFileName.Location = new System.Drawing.Point(16, 82);
            this.LogFileName.Name = "LogFileName";
            this.LogFileName.Size = new System.Drawing.Size(271, 20);
            this.LogFileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Folder de trabajo";
            // 
            // WorkingFolder
            // 
            this.WorkingFolder.Location = new System.Drawing.Point(16, 128);
            this.WorkingFolder.Name = "WorkingFolder";
            this.WorkingFolder.Size = new System.Drawing.Size(271, 20);
            this.WorkingFolder.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Folder de archivos temporales";
            // 
            // TemporaryFolder
            // 
            this.TemporaryFolder.Location = new System.Drawing.Point(16, 175);
            this.TemporaryFolder.Name = "TemporaryFolder";
            this.TemporaryFolder.Size = new System.Drawing.Size(271, 20);
            this.TemporaryFolder.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FileName);
            this.groupBox1.Controls.Add(this.TemporaryFolder);
            this.groupBox1.Controls.Add(this.LabelFileName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.WorkingFolder);
            this.groupBox1.Controls.Add(this.LogFileName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 420);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.White;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(12, 9);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(74, 13);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Text = "Procesando";
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.White;
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(800, 30);
            this.Header.TabIndex = 5;
            this.Header.TabStop = false;
            // 
            // ConfiguracionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.Header);
            this.Name = "ConfiguracionForm";
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.ConfiguracionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelFileName;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LogFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WorkingFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TemporaryFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.PictureBox Header;
    }
}