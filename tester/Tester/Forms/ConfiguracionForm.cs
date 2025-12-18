using System;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester.Forms {
    public partial class ConfiguracionForm : Form {
        private readonly IOriginService Service;

        public ConfiguracionForm(IOriginService service) {
            InitializeComponent();
            this.Service = service;
        }

        private void ConfiguracionForm_Load(object sender, EventArgs e) {
            this.Service.Configuration = this.Service.Configuration ?? new Jaeger.SAT.Catalogos.Configuration();
            this.FileName.Text = this.Service.Configuration.FileName;
            this.LogFileName.Text = this.Service.Configuration.LogFileName;
            this.WorkingFolder.Text = this.Service.Configuration.WorkingFolder;
            this.TemporaryFolder.Text = this.Service.Configuration.TemporaryFolder;
        }
    }
}
