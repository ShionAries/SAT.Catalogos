using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos;
using Jaeger.SAT.Catalogos.Scraping;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester {
    public partial class MainForm : Form {
        private UpdateOrigins _ScrapService;
        private BackgroundWorker _WorkerUpdate;
        private int _previousIndex;
        private bool _sortDirection;
        private Waiting4Form _Waiting;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            this._ScrapService = new UpdateOrigins();
            this._ScrapService.Read();
            this._ScrapService.NotificationEvent += Service_NotificationEvent;
            this.GridData.DataSource = this._ScrapService.Origins;
            this.Catalogos.Click += this.Catalogos_Click;
            this.Scraping.Click += this.Scraping_Click;
            this.Cerrar.Click += this.Cerrar_Click;
            this.OffProcesing();
            this.GridData.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(224, 224, 225) };
            this.GridData.AutoResizeColumns();
            this.GridData.ReadOnly = true;
            this.GridData.AllowUserToResizeRows = false;
        }

        private void Scraping_Click(object sender, EventArgs e) {
            this._Waiting = new Waiting4Form(() => {
                this._ScrapService.Run();
            }, "Cargando datos ...") {
                Text = ""
            };
            this._Waiting.ShowDialog(this);
            this.GridData.DataSource = this._ScrapService.Origins;
        }

        private void Descarga_Click(object sender, EventArgs e) {
            var folderBrowserDialog = new FolderBrowserDialog() { Description = "Selecciona ruta de descarga" };
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK) {
                this._ScrapService.WorkingFolder = folderBrowserDialog.SelectedPath;
            }
        }

        private void Catalogos_Click(object sender, EventArgs e) {
            if (this._WorkerUpdate == null) {
                this._WorkerUpdate = new BackgroundWorker();
                this._WorkerUpdate.DoWork += WorkerUpdate_DoWork;
                this._WorkerUpdate.RunWorkerCompleted += WorkerUpdate_RunWorkerCompleted;
            }
            if (this._WorkerUpdate.IsBusy)
                return;
            this._WorkerUpdate.RunWorkerAsync();
        }

        private void Cerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Service_NotificationEvent(object sender, string e) {
            this.Logger.AppendText(e + "\r\n");
            this._Waiting.MessageLabel.Text = e;
            this.StatusLabel.Text = e;
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
            //update.NotificationEvent += Service_NotificationEvent;
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

        private void GridData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button != MouseButtons.Right) {
                if (e.ColumnIndex == this._previousIndex) {
                    this._sortDirection = !this._sortDirection;
                }
                this.GridData.DataSource = this.SortData((List<IOrigin>)this.GridData.DataSource, this.GridData.Columns[e.ColumnIndex].Name, this._sortDirection);
                this._previousIndex = e.ColumnIndex;
            }
        }

        public List<IOrigin> SortData(List<IOrigin> data, string sCampo, bool bAscendente) {
            List<IOrigin> response;
            try {
                if (!sCampo.Contains("URL")) {
                    response = (bAscendente ? (
                        from x in data
                        orderby x.GetType().GetProperty(sCampo).GetValue(x)
                        select x).ToList<IOrigin>() : (
                        from x in data
                        orderby x.GetType().GetProperty(sCampo).GetValue(x) descending
                        select x).ToList<IOrigin>());
                } else {
                    response = data;
                }
            } catch (Exception exception) {
                throw exception;
            }
            return response;
        }

        private void Agregar_Click(object sender, EventArgs e) {

        }

        private void Delete_Click(object sender, EventArgs e) {
            if (this.GridData.CurrentRow != null) { 
                
            }
        }

        private void GridData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            this.MessageLabel.Text = $"{this.GridData.Rows.Count} filas. |";
        }
    }
}
