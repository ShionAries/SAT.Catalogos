namespace Tester {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.OriginisGroupBox = new System.Windows.Forms.GroupBox();
            this.GridData = new System.Windows.Forms.DataGridView();
            this.Catalogos = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.Scraping = new System.Windows.Forms.Button();
            this.Logger = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Descarga = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.PictureBox();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.OriginisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.BackColor = System.Drawing.Color.White;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(325, 17);
            this.HeaderLabel.TabIndex = 3;
            this.HeaderLabel.Text = "Servicio de Actualización de Catálogos SAT";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 353);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(701, 22);
            this.StatusBar.TabIndex = 4;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(84, 17);
            this.StatusLabel.Text = "Esperanding ...";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 40);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.OriginisGroupBox);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.Descarga);
            this.SplitContainer.Panel2.Controls.Add(this.Catalogos);
            this.SplitContainer.Panel2.Controls.Add(this.Cerrar);
            this.SplitContainer.Panel2.Controls.Add(this.Scraping);
            this.SplitContainer.Panel2.Controls.Add(this.Logger);
            this.SplitContainer.Size = new System.Drawing.Size(701, 313);
            this.SplitContainer.SplitterDistance = 397;
            this.SplitContainer.TabIndex = 5;
            // 
            // OriginisGroupBox
            // 
            this.OriginisGroupBox.Controls.Add(this.GridData);
            this.OriginisGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginisGroupBox.Location = new System.Drawing.Point(0, 0);
            this.OriginisGroupBox.Name = "OriginisGroupBox";
            this.OriginisGroupBox.Size = new System.Drawing.Size(397, 313);
            this.OriginisGroupBox.TabIndex = 0;
            this.OriginisGroupBox.TabStop = false;
            this.OriginisGroupBox.Text = "Origenes";
            // 
            // GridData
            // 
            this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridData.Location = new System.Drawing.Point(3, 16);
            this.GridData.Name = "GridData";
            this.GridData.RowHeadersVisible = false;
            this.GridData.Size = new System.Drawing.Size(391, 294);
            this.GridData.TabIndex = 0;
            this.GridData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridData_ColumnHeaderMouseClick);
            // 
            // Catalogos
            // 
            this.Catalogos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Catalogos.Location = new System.Drawing.Point(52, 281);
            this.Catalogos.Name = "Catalogos";
            this.Catalogos.Size = new System.Drawing.Size(75, 23);
            this.Catalogos.TabIndex = 6;
            this.Catalogos.Text = "Catalogos";
            this.Catalogos.UseVisualStyleBackColor = true;
            // 
            // Cerrar
            // 
            this.Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cerrar.Location = new System.Drawing.Point(214, 281);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 5;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            // 
            // Scraping
            // 
            this.Scraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Scraping.Location = new System.Drawing.Point(133, 281);
            this.Scraping.Name = "Scraping";
            this.Scraping.Size = new System.Drawing.Size(75, 23);
            this.Scraping.TabIndex = 4;
            this.Scraping.Text = "Scraping";
            this.Scraping.UseVisualStyleBackColor = true;
            // 
            // Logger
            // 
            this.Logger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Logger.Location = new System.Drawing.Point(3, 6);
            this.Logger.Multiline = true;
            this.Logger.Name = "Logger";
            this.Logger.Size = new System.Drawing.Size(294, 267);
            this.Logger.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Tester.Properties.Resources.sat30px;
            this.pictureBox1.Location = new System.Drawing.Point(659, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Descarga
            // 
            this.Descarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Descarga.Image = global::Tester.Properties.Resources.settings_16px;
            this.Descarga.Location = new System.Drawing.Point(11, 281);
            this.Descarga.Name = "Descarga";
            this.Descarga.Size = new System.Drawing.Size(35, 23);
            this.Descarga.TabIndex = 7;
            this.Descarga.UseVisualStyleBackColor = true;
            this.Descarga.Click += new System.EventHandler(this.Descarga_Click);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.White;
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(701, 40);
            this.Header.TabIndex = 2;
            this.Header.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 375);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.Header);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SAT Catálogos";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.OriginisGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.PictureBox Header;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.GroupBox OriginisGroupBox;
        private System.Windows.Forms.DataGridView GridData;
        private System.Windows.Forms.TextBox Logger;
        private System.Windows.Forms.Button Catalogos;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button Scraping;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Descarga;
    }
}