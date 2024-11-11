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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OriginisGroupBox = new System.Windows.Forms.GroupBox();
            this.GridData = new System.Windows.Forms.DataGridView();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownloadUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permitir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TControl = new System.Windows.Forms.ToolStrip();
            this.Agregar = new System.Windows.Forms.ToolStripButton();
            this.Editar = new System.Windows.Forms.ToolStripButton();
            this.Delete = new System.Windows.Forms.ToolStripButton();
            this.Guardar = new System.Windows.Forms.ToolStripButton();
            this.Contextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Verificar = new System.Windows.Forms.ToolStripMenuItem();
            this.Descargar = new System.Windows.Forms.ToolStripMenuItem();
            this.Actualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.OriginisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            this.TControl.SuspendLayout();
            this.Contextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginisGroupBox
            // 
            this.OriginisGroupBox.Controls.Add(this.GridData);
            this.OriginisGroupBox.Controls.Add(this.TControl);
            this.OriginisGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginisGroupBox.Location = new System.Drawing.Point(5, 5);
            this.OriginisGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.OriginisGroupBox.Name = "OriginisGroupBox";
            this.OriginisGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.OriginisGroupBox.Size = new System.Drawing.Size(790, 440);
            this.OriginisGroupBox.TabIndex = 1;
            this.OriginisGroupBox.TabStop = false;
            this.OriginisGroupBox.Text = "Origenes";
            // 
            // GridData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.GridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.Url,
            this.LastVersion,
            this.DestinationFileName,
            this.DownloadUrl,
            this.Permitir});
            this.GridData.ContextMenuStrip = this.Contextual;
            this.GridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridData.Location = new System.Drawing.Point(5, 43);
            this.GridData.Name = "GridData";
            this.GridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.GridData.RowHeadersVisible = false;
            this.GridData.Size = new System.Drawing.Size(780, 392);
            this.GridData.TabIndex = 0;
            // 
            // NameCol
            // 
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "Nombre";
            this.NameCol.Name = "NameCol";
            this.NameCol.Width = 150;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            // 
            // LastVersion
            // 
            this.LastVersion.DataPropertyName = "LastVersion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.LastVersion.DefaultCellStyle = dataGridViewCellStyle2;
            this.LastVersion.HeaderText = "Últ. Actualización";
            this.LastVersion.Name = "LastVersion";
            // 
            // DestinationFileName
            // 
            this.DestinationFileName.DataPropertyName = "DestinationFileName";
            this.DestinationFileName.HeaderText = "Destino";
            this.DestinationFileName.Name = "DestinationFileName";
            // 
            // DownloadUrl
            // 
            this.DownloadUrl.DataPropertyName = "DownloadUrl";
            this.DownloadUrl.HeaderText = "Download";
            this.DownloadUrl.Name = "DownloadUrl";
            // 
            // Permitir
            // 
            this.Permitir.DataPropertyName = "AllowUpdate";
            this.Permitir.HeaderText = "Permitir";
            this.Permitir.Name = "Permitir";
            this.Permitir.Width = 50;
            // 
            // TControl
            // 
            this.TControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Agregar,
            this.Editar,
            this.Delete,
            this.Guardar});
            this.TControl.Location = new System.Drawing.Point(5, 18);
            this.TControl.Name = "TControl";
            this.TControl.Size = new System.Drawing.Size(780, 25);
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
            // Editar
            // 
            this.Editar.Image = global::Tester.Properties.Resources.edit_16px;
            this.Editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(57, 22);
            this.Editar.Text = "Editar";
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
            // Contextual
            // 
            this.Contextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Verificar,
            this.Descargar,
            this.Actualizar});
            this.Contextual.Name = "Contextual";
            this.Contextual.Size = new System.Drawing.Size(181, 92);
            // 
            // Verificar
            // 
            this.Verificar.Name = "Verificar";
            this.Verificar.Size = new System.Drawing.Size(180, 22);
            this.Verificar.Text = "Verificar";
            // 
            // Descargar
            // 
            this.Descargar.Name = "Descargar";
            this.Descargar.Size = new System.Drawing.Size(180, 22);
            this.Descargar.Text = "Decargar";
            // 
            // Actualizar
            // 
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(180, 22);
            this.Actualizar.Text = "Actualizar";
            // 
            // OriginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OriginisGroupBox);
            this.Name = "OriginsForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Origenes de datos";
            this.Load += new System.EventHandler(this.OriginsForm_Load);
            this.OriginisGroupBox.ResumeLayout(false);
            this.OriginisGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            this.TControl.ResumeLayout(false);
            this.TControl.PerformLayout();
            this.Contextual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox OriginisGroupBox;
        private System.Windows.Forms.DataGridView GridData;
        private System.Windows.Forms.ToolStrip TControl;
        private System.Windows.Forms.ToolStripButton Agregar;
        private System.Windows.Forms.ToolStripButton Delete;
        private System.Windows.Forms.ToolStripButton Guardar;
        private System.Windows.Forms.ToolStripButton Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownloadUrl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Permitir;
        private System.Windows.Forms.ContextMenuStrip Contextual;
        private System.Windows.Forms.ToolStripMenuItem Verificar;
        private System.Windows.Forms.ToolStripMenuItem Descargar;
        private System.Windows.Forms.ToolStripMenuItem Actualizar;
    }
}