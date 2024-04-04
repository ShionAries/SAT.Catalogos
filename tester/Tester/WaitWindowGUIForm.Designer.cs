namespace Tester {
    partial class WaitWindowGUIForm {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent() {
            this.Marque = new System.Windows.Forms.ProgressBar();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Marque
            // 
            this.Marque.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Marque.Location = new System.Drawing.Point(0, 25);
            this.Marque.Name = "Marque";
            this.Marque.Size = new System.Drawing.Size(286, 31);
            this.Marque.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Marque.TabIndex = 0;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(5, 6);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(74, 13);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "Procesando ..";
            // 
            // WaitWindowGUIForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(286, 56);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.Marque);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitWindowGUIForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WaitWindowGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ProgressBar Marque;
        public System.Windows.Forms.Label MessageLabel;
    }
}