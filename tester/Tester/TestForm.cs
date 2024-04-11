using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos;

namespace Tester {
    public partial class TestForm : Form {
        public TestForm() {
            InitializeComponent();
        }
        object result;
        private void TestForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
        }

        private async void Testing_Scraping_Click(object sender, EventArgs e) {
            //this.result = WaitWindow.Show(this.WorkerMethod);
            await this.Procesar();
        }

        private void Testing_Catalogos_Click(object sender, EventArgs e) {
            var update = new UpdateDatabase(@"C:\Jaeger\Jaeger.Temporal");
            update.Run();
        }

        private void End_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void WorkerMethod(object sender, WaitWindowEventArgs e) {
            e.Window.Message = "Actualizando origenes";
            var service = new Jaeger.SAT.Catalogos.Scraping.UpdateOrigins();
            service.NotificationEvent += Service_NotificationEvent;
            e.Window.Message = this.Text;
            Application.DoEvents();
            service.Run();
        }

        private void Service_NotificationEvent(object sender, string e) {
            this.textBox1.Text += e + "\r\n";
        }

        private Task Procesar() {
            return Task.Run(() => {
                var service = new Jaeger.SAT.Catalogos.Scraping.UpdateOrigins();
                service.NotificationEvent += Service_NotificationEvent;
                service.Run();
            });
        }
    }
}
