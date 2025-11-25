namespace Tester.Forms {
    partial class TestingForm {
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
            this.Originlabel = new System.Windows.Forms.Label();
            this.Tipolabel = new System.Windows.Forms.Label();
            this.Origins = new System.Windows.Forms.ComboBox();
            this.SelectOrigin = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Nombrelabel = new System.Windows.Forms.Label();
            this.Urllabel = new System.Windows.Forms.Label();
            this.LastVersionlabel = new System.Windows.Forms.Label();
            this.DownloadLabel = new System.Windows.Forms.Label();
            this.DestinationFileNameLabel = new System.Windows.Forms.Label();
            this.LinkTextLabel = new System.Windows.Forms.Label();
            this.OriginName = new System.Windows.Forms.TextBox();
            this.Url = new System.Windows.Forms.TextBox();
            this.LastVersion = new System.Windows.Forms.TextBox();
            this.DownloadUrl = new System.Windows.Forms.TextBox();
            this.DestinationFileName = new System.Windows.Forms.TextBox();
            this.LinkText = new System.Windows.Forms.TextBox();
            this.AllowUpdate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Originlabel
            // 
            this.Originlabel.AutoSize = true;
            this.Originlabel.Location = new System.Drawing.Point(19, 16);
            this.Originlabel.Name = "Originlabel";
            this.Originlabel.Size = new System.Drawing.Size(41, 13);
            this.Originlabel.TabIndex = 0;
            this.Originlabel.Text = "Origen:";
            // 
            // Tipolabel
            // 
            this.Tipolabel.AutoSize = true;
            this.Tipolabel.Location = new System.Drawing.Point(19, 43);
            this.Tipolabel.Name = "Tipolabel";
            this.Tipolabel.Size = new System.Drawing.Size(80, 13);
            this.Tipolabel.TabIndex = 1;
            this.Tipolabel.Text = "Tipo de Origen:";
            // 
            // Origins
            // 
            this.Origins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Origins.Enabled = false;
            this.Origins.FormattingEnabled = true;
            this.Origins.Location = new System.Drawing.Point(66, 13);
            this.Origins.Name = "Origins";
            this.Origins.Size = new System.Drawing.Size(191, 21);
            this.Origins.TabIndex = 2;
            // 
            // SelectOrigin
            // 
            this.SelectOrigin.AutoSize = true;
            this.SelectOrigin.Location = new System.Drawing.Point(263, 15);
            this.SelectOrigin.Name = "SelectOrigin";
            this.SelectOrigin.Size = new System.Drawing.Size(114, 17);
            this.SelectOrigin.TabIndex = 3;
            this.SelectOrigin.Text = "Seleccionar origen";
            this.SelectOrigin.UseVisualStyleBackColor = true;
            this.SelectOrigin.CheckedChanged += new System.EventHandler(this.SelectOrigin_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Scraping",
            "Constant"});
            this.comboBox2.Location = new System.Drawing.Point(105, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(152, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // Nombrelabel
            // 
            this.Nombrelabel.AutoSize = true;
            this.Nombrelabel.Location = new System.Drawing.Point(14, 23);
            this.Nombrelabel.Name = "Nombrelabel";
            this.Nombrelabel.Size = new System.Drawing.Size(47, 13);
            this.Nombrelabel.TabIndex = 5;
            this.Nombrelabel.Text = "Nombre:";
            // 
            // Urllabel
            // 
            this.Urllabel.AutoSize = true;
            this.Urllabel.Location = new System.Drawing.Point(14, 50);
            this.Urllabel.Name = "Urllabel";
            this.Urllabel.Size = new System.Drawing.Size(32, 13);
            this.Urllabel.TabIndex = 6;
            this.Urllabel.Text = "URL:";
            // 
            // LastVersionlabel
            // 
            this.LastVersionlabel.AutoSize = true;
            this.LastVersionlabel.Location = new System.Drawing.Point(14, 83);
            this.LastVersionlabel.Name = "LastVersionlabel";
            this.LastVersionlabel.Size = new System.Drawing.Size(121, 13);
            this.LastVersionlabel.TabIndex = 7;
            this.LastVersionlabel.Text = "Fecha de Actualización:";
            // 
            // DownloadLabel
            // 
            this.DownloadLabel.AutoSize = true;
            this.DownloadLabel.Location = new System.Drawing.Point(14, 113);
            this.DownloadLabel.Name = "DownloadLabel";
            this.DownloadLabel.Size = new System.Drawing.Size(92, 13);
            this.DownloadLabel.TabIndex = 8;
            this.DownloadLabel.Text = "Liga de descarga:";
            // 
            // DestinationFileNameLabel
            // 
            this.DestinationFileNameLabel.AutoSize = true;
            this.DestinationFileNameLabel.Location = new System.Drawing.Point(14, 139);
            this.DestinationFileNameLabel.Name = "DestinationFileNameLabel";
            this.DestinationFileNameLabel.Size = new System.Drawing.Size(139, 13);
            this.DestinationFileNameLabel.TabIndex = 9;
            this.DestinationFileNameLabel.Text = "Nombre del archivo destino:";
            // 
            // LinkTextLabel
            // 
            this.LinkTextLabel.AutoSize = true;
            this.LinkTextLabel.Location = new System.Drawing.Point(14, 165);
            this.LinkTextLabel.Name = "LinkTextLabel";
            this.LinkTextLabel.Size = new System.Drawing.Size(76, 13);
            this.LinkTextLabel.TabIndex = 10;
            this.LinkTextLabel.Text = "Búsqueda por:";
            // 
            // OriginName
            // 
            this.OriginName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginName.Location = new System.Drawing.Point(67, 19);
            this.OriginName.Name = "OriginName";
            this.OriginName.Size = new System.Drawing.Size(596, 20);
            this.OriginName.TabIndex = 11;
            // 
            // Url
            // 
            this.Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Url.Location = new System.Drawing.Point(67, 46);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(596, 20);
            this.Url.TabIndex = 11;
            // 
            // LastVersion
            // 
            this.LastVersion.Location = new System.Drawing.Point(141, 79);
            this.LastVersion.Name = "LastVersion";
            this.LastVersion.Size = new System.Drawing.Size(112, 20);
            this.LastVersion.TabIndex = 11;
            // 
            // DownloadUrl
            // 
            this.DownloadUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadUrl.Location = new System.Drawing.Point(112, 109);
            this.DownloadUrl.Name = "DownloadUrl";
            this.DownloadUrl.Size = new System.Drawing.Size(551, 20);
            this.DownloadUrl.TabIndex = 11;
            // 
            // DestinationFileName
            // 
            this.DestinationFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationFileName.Location = new System.Drawing.Point(159, 135);
            this.DestinationFileName.Name = "DestinationFileName";
            this.DestinationFileName.Size = new System.Drawing.Size(504, 20);
            this.DestinationFileName.TabIndex = 11;
            // 
            // LinkText
            // 
            this.LinkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkText.Location = new System.Drawing.Point(101, 161);
            this.LinkText.Name = "LinkText";
            this.LinkText.Size = new System.Drawing.Size(562, 20);
            this.LinkText.TabIndex = 11;
            // 
            // AllowUpdate
            // 
            this.AllowUpdate.AutoSize = true;
            this.AllowUpdate.Location = new System.Drawing.Point(17, 190);
            this.AllowUpdate.Name = "AllowUpdate";
            this.AllowUpdate.Size = new System.Drawing.Size(125, 17);
            this.AllowUpdate.TabIndex = 12;
            this.AllowUpdate.Text = "Permitir actualización";
            this.AllowUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OriginName);
            this.groupBox1.Controls.Add(this.AllowUpdate);
            this.groupBox1.Controls.Add(this.Nombrelabel);
            this.groupBox1.Controls.Add(this.LinkText);
            this.groupBox1.Controls.Add(this.Urllabel);
            this.groupBox1.Controls.Add(this.DestinationFileName);
            this.groupBox1.Controls.Add(this.LastVersionlabel);
            this.groupBox1.Controls.Add(this.DownloadUrl);
            this.groupBox1.Controls.Add(this.DownloadLabel);
            this.groupBox1.Controls.Add(this.LastVersion);
            this.groupBox1.Controls.Add(this.DestinationFileNameLabel);
            this.groupBox1.Controls.Add(this.Url);
            this.groupBox1.Controls.Add(this.LinkTextLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 244);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Origins);
            this.panel1.Controls.Add(this.Originlabel);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.Tipolabel);
            this.panel1.Controls.Add(this.SelectOrigin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 75);
            this.panel1.TabIndex = 14;
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "TestingForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Testing";
            this.Load += new System.EventHandler(this.TestingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Originlabel;
        private System.Windows.Forms.Label Tipolabel;
        private System.Windows.Forms.ComboBox Origins;
        private System.Windows.Forms.CheckBox SelectOrigin;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Nombrelabel;
        private System.Windows.Forms.Label Urllabel;
        private System.Windows.Forms.Label LastVersionlabel;
        private System.Windows.Forms.Label DownloadLabel;
        private System.Windows.Forms.Label DestinationFileNameLabel;
        private System.Windows.Forms.Label LinkTextLabel;
        private System.Windows.Forms.TextBox OriginName;
        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.TextBox LastVersion;
        private System.Windows.Forms.TextBox DownloadUrl;
        private System.Windows.Forms.TextBox DestinationFileName;
        private System.Windows.Forms.TextBox LinkText;
        private System.Windows.Forms.CheckBox AllowUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}