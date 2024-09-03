using Jaeger.SAT.Catalogos.Scraping;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester {
    public partial class UpdateForm : Form {
        private OriginService _ScrapService;
        private UpdateService _UpdateService;
        private Waiting4Form _Waiting;

        public UpdateForm(OriginService originService) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this._ScrapService = originService;
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
                this._ScrapService.DataSource = this._UpdateService.Run(this._ScrapService.DataSource);
            }, "Cargando datos ...") {
                Text = ""
            };
            this._Waiting.ShowDialog(this);
        }
    }
}
