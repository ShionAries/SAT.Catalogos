using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester.Forms {
    public partial class MainMenuForm : Form {
        private IOriginService Service;
        private Panel leftBorderBtn;
        private Button currentButton;
        private Form currentChildForm;

        private struct RGBColors {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        public MainMenuForm() {
            InitializeComponent();
            this.leftBorderBtn = new Panel {
                Size = new Size(7, 60)
            };
            this.panelMenu.Controls.Add(this.leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void MainMenuForm_Load(object sender, EventArgs e) {
            this.Service = new OriginService();
            this.ControlBtn.PerformClick();
            this.VersionLabel.Text = $"Version {Application.ProductVersion}";
        }

        private void ActiveButton(object sender, Color color) {
            if (sender != null) {
                DisableButton();
                currentButton = sender as Button;
                currentButton.BackColor = SystemColors.Control;
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleCenter;

                this.leftBorderBtn.BackColor = color;
                this.leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                this.leftBorderBtn.Visible = true;
                this.leftBorderBtn.BringToFront();

                this.iconCurrentChildForm.Image = currentButton.Image;
                this.iconCurrentChildForm.ForeColor = color;
            }
        }

        private void DisableButton() {
            if (currentButton != null) {
                currentButton.BackColor = SystemColors.ControlDark;
                currentButton.ForeColor = SystemColors.ControlText;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Reset() {
            DisableButton();
            this.leftBorderBtn.Visible = false;
            this.iconCurrentChildForm.Image = null;
            this.label1.ForeColor = Color.MediumPurple;
            this.label1.Text = "Start";
        }

        private void OpenChildForm(Form childForm) {
            if (currentChildForm != null) {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.label1.Text = childForm.Text;
        }

        private void HomeBtn_Click(object sender, EventArgs e) {
            if (currentChildForm != null) {
                currentChildForm.Close();
            }
            Reset();
        }

        private void ControlBtn_Click(object sender, EventArgs e) {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new OriginsForm(this.Service));
        }

        private void UpdateBtn_Click(object sender, EventArgs e) {
            ActiveButton(sender, RGBColors.color2);
            //OpenChildForm(new UpdateForm(this.Service));
        }

        private void TestingBtn_Click(object sender, EventArgs e) {
            ActiveButton(sender, RGBColors.color3);
            OpenChildForm(new RepositoryTestForm());
        }

        private void ConfiguracionBtn_Click(object sender, EventArgs e) {
            ActiveButton(sender, RGBColors.color4);
            OpenChildForm(new ConfiguracionForm(this.Service));
        }

        private void ExitBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL")]
        private extern static void SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
