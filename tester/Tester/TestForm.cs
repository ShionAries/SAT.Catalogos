using System;
using System.Windows.Forms;

namespace Tester {
    public partial class TestForm : Form {
        public TestForm() {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e) {
            var service = new Jaeger.SAT.Catalogos.Scraping.UpdateOrigins();
            service.Run();
        }
    }
}
