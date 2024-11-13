using System;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester {
    public partial class OriginForm : Form {
        private IOriginService _ScrapService;
        private IOrigin origin;

        public OriginForm(IOriginService scrapService, IOrigin origin) {
            InitializeComponent();
            this._ScrapService = scrapService;
            this.origin = origin;
        }

        private void OriginForm_Load(object sender, EventArgs e) {
            if (origin != null) { 
                this.OriginName.Text = origin.Name.ToString();
                this.Url.Text = origin.Url;
                this.DownloadUrl.Text = origin.DownloadUrl;
                this.DestinationFileName.Text = origin.DestinationFilename;
                this.LinkText.Text = origin.LinkText;
                this.AllowUpdate.Checked = origin.AllowUpdate;
                this.LastVersion.Text = origin.LastVersion.Value.ToString();
            }
        }

        private void Cancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Guardar_Click(object sender, EventArgs e) {

        }
    }
}
