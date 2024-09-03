namespace Tester {
    partial class OriginsForm {
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
            this.OriginisGroupBox = new System.Windows.Forms.GroupBox();
            this.GridData = new System.Windows.Forms.DataGridView();
            this.TControl = new System.Windows.Forms.ToolStrip();
            this.Agregar = new System.Windows.Forms.ToolStripButton();
            this.Delete = new System.Windows.Forms.ToolStripButton();
            this.Guardar = new System.Windows.Forms.ToolStripButton();
            this.OriginisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            this.TControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginisGroupBox
            // 
            this.OriginisGroupBox.Controls.Add(this.GridData);
            this.OriginisGroupBox.Controls.Add(this.TControl);
            this.OriginisGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginisGroupBox.Location = new System.Drawing.Point(0, 0);
            this.OriginisGroupBox.Name = "OriginisGroupBox";
            this.OriginisGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.OriginisGroupBox.Size = new System.Drawing.Size(800, 450);
            this.OriginisGroupBox.TabIndex = 1;
            this.OriginisGroupBox.TabStop = false;
            this.OriginisGroupBox.Text = "Origenes";
            // 
            // GridData
            // 
            this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridData.Location = new System.Drawing.Point(5, 43);
            this.GridData.Name = "GridData";
            this.GridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.GridData.RowHeadersVisible = false;
            this.GridData.Size = new System.Drawing.Size(790, 402);
            this.GridData.TabIndex = 0;
            // 
            // TControl
            // 
            this.TControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Agregar,
            this.Delete,
            this.Guardar});
            this.TControl.Location = new System.Drawing.Point(5, 18);
            this.TControl.Name = "TControl";
            this.TControl.Size = new System.Drawing.Size(790, 25);
            this.TControl.TabIndex = 1;
            this.TControl.Text = "toolStrip1";
            // 
            // Agregar
            // 
            this.Agregar.Image = global::Tester.Properties.Resources.add_16px;
            this.Agregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(69, 22);
            this.Agregar.Text = "Agregar";
            // 
            // Delete
            // 
            this.Delete.Image = global::Tester.Properties.Resources.delete_16px;
            this.Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(74, 22);
            this.Delete.Text = "Remover";
            // 
            // Guardar
            // 
            this.Guardar.Image = global::Tester.Properties.Resources.save_16px;
            this.Guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(69, 22);
            this.Guardar.Text = "Guardar";
            // 
            // OriginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OriginisGroupBox);
            this.Name = "OriginsForm";
            this.Text = "Origenes de datos";
            this.Load += new System.EventHandler(this.OriginsForm_Load);
            this.OriginisGroupBox.ResumeLayout(false);
            this.OriginisGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            this.TControl.ResumeLayout(false);
            this.TControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox OriginisGroupBox;
        private System.Windows.Forms.DataGridView GridData;
        private System.Windows.Forms.ToolStrip TControl;
        private System.Windows.Forms.ToolStripButton Agregar;
        private System.Windows.Forms.ToolStripButton Delete;
        private System.Windows.Forms.ToolStripButton Guardar;
    }
}