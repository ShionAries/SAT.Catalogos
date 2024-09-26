using System;
using System.Linq;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos;
using Jaeger.SAT.Catalogos.Builder;
using Jaeger.SAT.Catalogos.Scraping.Helpers;

namespace Tester {
    public partial class UpdateForm : Form {
        private OriginService _ScrapService;
        private UpdateService _UpdateService;
        private Waiting4Form _Waiting;
        private ScrapingService scrapingService;
        public UpdateForm(OriginService originService) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this._ScrapService = originService;
        }

        private void UpdateForm_Load(object sender, EventArgs e) {
            var builder = ScrapingServiceBuilder.Create().Review(Jaeger.SAT.Catalogos.Scraping.ValueObjects.SourceIdentifierEnum.Articulo69B).Upgrader();
            var origen = builder.GetOrigin();
            var update = builder.Update();
            update.Origin(origen).Update(Jaeger.SAT.Catalogos.Scraping.ValueObjects.SourceIdentifierEnum.Articulo69B).Import();
            
            return;
            this.Start.Click += StartButton_Click;
            this._UpdateService = new UpdateService();
            this._UpdateService.NotificationEvent += _UpdateService_NotificationEvent;
            this.scrapingService = new ScrapingService();
            this.scrapingService.Upgrader();
        }

        private void _UpdateService_NotificationEvent(object sender, string e) {
            this.Logger.AppendText(e + "\r\n");
            this._Waiting.MessageLabel.Text = e;
            Application.DoEvents();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            this._Waiting = new Waiting4Form(() => {
                this.scrapingService.Review(this._ScrapService.DataSource);
                this.scrapingService.Upgrader();
                this._ScrapService.DataSource = this.scrapingService.GetOrigins();

            }, "Actualizando datos ...") {
                Text = ""
            };
            this._Waiting.ShowDialog(this);
        }
    }
}
