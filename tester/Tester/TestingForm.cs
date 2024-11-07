using System;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester {
    public partial class TestingForm : Form {
        private IOriginService _ScrapService;

        public TestingForm(IOriginService originService) {
            InitializeComponent();
            _ScrapService = originService;
        }

        private void TestingForm_Load(object sender, EventArgs e) {
        }

        private void SelectOrigin_CheckedChanged(object sender, EventArgs e) {
            this.Origins.Enabled = this.SelectOrigin.Checked;
            if (this.SelectOrigin.Checked) {
                this.Origins.DataSource = this._ScrapService.DataSource;
                this.Origins.DisplayMember = "Name";
                this.Origins.ValueMember = "Name";
            }
        }
    }
}
