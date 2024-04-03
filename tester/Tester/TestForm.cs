using System;
using System.Windows.Forms;

namespace Tester {
    public partial class TestForm : Form {
        public TestForm() {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e) {

        }

        private void Start_Click(object sender, EventArgs e) {
            object result = WaitWindow.Show(this.WorkerMethod);
        }

        private void WorkerMethod(object sender, WaitWindowEventArgs e) {
            e.Window.Message = "Actualizando orignes";
            var service = new Jaeger.SAT.Catalogos.Scraping.UpdateOrigins();
            service.Run();
        }

        private void End_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
