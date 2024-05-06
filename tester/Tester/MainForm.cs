using System;
using System.ComponentModel;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos;
using Jaeger.SAT.Catalogos.Scraping;

namespace Tester {
    public partial class MainForm : Form {
        private UpdateOrigins _ScrapService;
        private BackgroundWorker _WorkerScraping;
        private BackgroundWorker _WorkerUpdate;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            this._ScrapService = new UpdateOrigins();
            this._ScrapService.ReadOrigins();
            this.GridData.DataSource = this._ScrapService.Origins;
            this.Catalogos.Click += this.Catalogos_Click;
            this.Scraping.Click+= this.Scraping_Click;
            this.Cerrar.Click += this.Cerrar_Click;
            this.OffProcesing();
        }

        private void Scraping_Click(object sender, EventArgs e) {
            if (this._WorkerScraping == null) {
                this._WorkerScraping = new BackgroundWorker();
                this._WorkerScraping.DoWork += WorkerScraping_DoWork;
                this._WorkerScraping.RunWorkerCompleted += WorkerScraping_RunWorkerCompleted;
            }

            if (this._WorkerScraping.IsBusy) return;
            this._WorkerScraping.RunWorkerAsync();
        }

        private void Catalogos_Click(object sender, EventArgs e) {
            if (this._WorkerUpdate == null) {
                this._WorkerUpdate = new BackgroundWorker();
                this._WorkerUpdate.DoWork += WorkerUpdate_DoWork;
                this._WorkerUpdate.RunWorkerCompleted += WorkerUpdate_RunWorkerCompleted;
            }
            if (this._WorkerUpdate.IsBusy) return;
            this._WorkerUpdate.RunWorkerAsync();
        }

        private void Cerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Service_NotificationEvent(object sender, string e) {
            this.Logger.Text += e + "\r\n";
            Application.DoEvents();
        }

        #region scraping
        private void WorkerScraping_DoWork(object sender, DoWorkEventArgs e) {
            this.OnProcesing();
            this._ScrapService.NotificationEvent += Service_NotificationEvent;
            this._ScrapService.Run();
        }

        private void WorkerScraping_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.GridData.DataSource = this._ScrapService.Origins;
            this.OffProcesing();
            Application.DoEvents();
        }
        #endregion

        #region update catalogos
        private void WorkerUpdate_DoWork(object sender, DoWorkEventArgs e) {
            this.OnProcesing();
            var update = new UpdateDatabase(@"C:\Jaeger\Jaeger.Temporal");
            update.Run();
        }

        private void WorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.OffProcesing();
            Application.DoEvents();
        }
        #endregion

        private void OnProcesing() {
            this.Cerrar.Enabled = false;
            this.Catalogos.Enabled = false;
            this.Scraping.Enabled = false;
            this.ProgressBar.Visible = true;
            this.StatusLabel.Text = "Procesando ...";
            Application.DoEvents();
        }

        private void OffProcesing() {
            this.Cerrar.Enabled = true;
            this.Catalogos.Enabled = true;
            this.Scraping.Enabled = true;
            this.ProgressBar.Visible = false;
            this.StatusLabel.Text = "Proceso terminado.";
            Application.DoEvents();
        }
    }
}
