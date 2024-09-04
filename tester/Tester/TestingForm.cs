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
    public partial class TestingForm : Form {
        private OriginService _ScrapService;

        public TestingForm(OriginService originService) {
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
