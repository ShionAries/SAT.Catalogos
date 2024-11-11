namespace Tester {
    partial class MainMenuForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.SalirBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.TestingBrn = new System.Windows.Forms.Button();
            this.UpdatesBtn = new System.Windows.Forms.Button();
            this.ControlBtn = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.BtnHome = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconCurrentChildForm = new System.Windows.Forms.PictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMenu.Controls.Add(this.SalirBtn);
            this.panelMenu.Controls.Add(this.SettingsBtn);
            this.panelMenu.Controls.Add(this.TestingBrn);
            this.panelMenu.Controls.Add(this.UpdatesBtn);
            this.panelMenu.Controls.Add(this.ControlBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(5, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 476);
            this.panelMenu.TabIndex = 0;
            // 
            // SalirBtn
            // 
            this.SalirBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SalirBtn.FlatAppearance.BorderSize = 0;
            this.SalirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SalirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalirBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SalirBtn.Image = global::Tester.Properties.Resources.close_window_32px;
            this.SalirBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SalirBtn.Location = new System.Drawing.Point(0, 310);
            this.SalirBtn.Name = "SalirBtn";
            this.SalirBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.SalirBtn.Size = new System.Drawing.Size(220, 60);
            this.SalirBtn.TabIndex = 5;
            this.SalirBtn.Text = "Salir";
            this.SalirBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SalirBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SalirBtn.UseVisualStyleBackColor = true;
            this.SalirBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsBtn.FlatAppearance.BorderSize = 0;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SettingsBtn.Image = global::Tester.Properties.Resources.settings_32px;
            this.SettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsBtn.Location = new System.Drawing.Point(0, 250);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.SettingsBtn.Size = new System.Drawing.Size(220, 60);
            this.SettingsBtn.TabIndex = 4;
            this.SettingsBtn.Text = "Configuración";
            this.SettingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.ConfiguracionBtn_Click);
            // 
            // TestingBrn
            // 
            this.TestingBrn.Dock = System.Windows.Forms.DockStyle.Top;
            this.TestingBrn.FlatAppearance.BorderSize = 0;
            this.TestingBrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestingBrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestingBrn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TestingBrn.Image = global::Tester.Properties.Resources.test_lab_30px;
            this.TestingBrn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TestingBrn.Location = new System.Drawing.Point(0, 190);
            this.TestingBrn.Name = "TestingBrn";
            this.TestingBrn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.TestingBrn.Size = new System.Drawing.Size(220, 60);
            this.TestingBrn.TabIndex = 3;
            this.TestingBrn.Text = "Prueba";
            this.TestingBrn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TestingBrn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TestingBrn.UseVisualStyleBackColor = true;
            this.TestingBrn.Click += new System.EventHandler(this.TestingBtn_Click);
            // 
            // UpdatesBtn
            // 
            this.UpdatesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdatesBtn.FlatAppearance.BorderSize = 0;
            this.UpdatesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatesBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UpdatesBtn.Image = global::Tester.Properties.Resources.available_updates_32px;
            this.UpdatesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdatesBtn.Location = new System.Drawing.Point(0, 130);
            this.UpdatesBtn.Name = "UpdatesBtn";
            this.UpdatesBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.UpdatesBtn.Size = new System.Drawing.Size(220, 60);
            this.UpdatesBtn.TabIndex = 2;
            this.UpdatesBtn.Text = "Actualización";
            this.UpdatesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdatesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdatesBtn.UseVisualStyleBackColor = true;
            this.UpdatesBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // ControlBtn
            // 
            this.ControlBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBtn.FlatAppearance.BorderSize = 0;
            this.ControlBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ControlBtn.Image = global::Tester.Properties.Resources.database_administrator_32px;
            this.ControlBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ControlBtn.Location = new System.Drawing.Point(0, 70);
            this.ControlBtn.Name = "ControlBtn";
            this.ControlBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ControlBtn.Size = new System.Drawing.Size(220, 60);
            this.ControlBtn.TabIndex = 1;
            this.ControlBtn.Text = "Control";
            this.ControlBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ControlBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ControlBtn.UseVisualStyleBackColor = true;
            this.ControlBtn.Click += new System.EventHandler(this.ControlBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.HeaderLabel);
            this.panelLogo.Controls.Add(this.BtnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 70);
            this.panelLogo.TabIndex = 1;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(50, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(164, 54);
            this.HeaderLabel.TabIndex = 4;
            this.HeaderLabel.Text = "Servicio de Actualización de Catálogos SAT";
            // 
            // BtnHome
            // 
            this.BtnHome.Image = global::Tester.Properties.Resources.sat30px;
            this.BtnHome.Location = new System.Drawing.Point(12, 13);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(32, 32);
            this.BtnHome.TabIndex = 1;
            this.BtnHome.TabStop = false;
            this.BtnHome.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(42, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Home";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(225, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(789, 60);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconCurrentChildForm.Image = global::Tester.Properties.Resources.home_page_32px;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(6, 12);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(30, 30);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            this.iconCurrentChildForm.Text = "Start";
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(225, 60);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(789, 10);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.SystemColors.Control;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(225, 70);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(789, 406);
            this.panelDesktop.TabIndex = 3;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 481);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button ControlBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Button TestingBrn;
        private System.Windows.Forms.Button UpdatesBtn;
        private System.Windows.Forms.PictureBox BtnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.PictureBox iconCurrentChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Button SalirBtn;
    }
}