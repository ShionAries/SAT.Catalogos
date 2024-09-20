using System;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping;
using Jaeger.SAT.Catalogos.Scraping.Builder;
using Jaeger.SAT.Catalogos.Scraping.Helpers;

namespace Tester {
    public partial class UpdateForm : Form {
        private OriginService _ScrapService;
        private UpdateService _UpdateService;
        private Waiting4Form _Waiting;
        private IUpdaterServiceBuilder Service;

        public UpdateForm(OriginService originService) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this._ScrapService = originService;
            this.Service = UpdateService.Create();
            
        }

        private void UpdateForm_Load(object sender, EventArgs e) {
            this.Start.Click += StartButton_Click;
            this._UpdateService = new UpdateService();
            this._UpdateService.NotificationEvent += _UpdateService_NotificationEvent;
        }

        private void _UpdateService_NotificationEvent(object sender, string e) {
            this.Logger.AppendText(e + "\r\n");
            this._Waiting.MessageLabel.Text = e;
            Application.DoEvents();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            this._Waiting = new Waiting4Form(() => {
                var d0 = this.Service.Update(this._ScrapService.DataSource).Execute();
                d0.Download();
                this._ScrapService.DataSource = this.Service.Origins;

            }, "Actualizando datos ...") {
                Text = ""
            };
            this._Waiting.ShowDialog(this);
        }
    }
}
