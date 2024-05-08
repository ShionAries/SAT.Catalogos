using System;
using System.Windows.Forms;

namespace Tester {
    public partial class Waiting4Form : Form {
        private int _WaitTime;
        private bool _CancelEnable;
        private IAsyncResult _AsyncResult;
        private MethodInvoker _method;

        public string Message { get; set; }
        public int TimeSpan { get; set; }

        public Waiting4Form(MethodInvoker method, string waitMessage, bool cancelEnable, bool timerVisable) {
            Initialize(method, waitMessage, cancelEnable, timerVisable);
        }

        private void Initialize(MethodInvoker method, string waitMessage, bool cancelEnable, bool timerVisable) {
            InitializeComponent();
            // Rimless 
            this.FormBorderStyle = FormBorderStyle.None;
            // Start in the middle of the parent form
            this.StartPosition = FormStartPosition.CenterParent;
            // Not in the taskbar display
            this.ShowInTaskbar = false;
            this.MessageLabel.Text = waitMessage;
            TimeSpan = 500;
            Message = string.Empty;
            _CancelEnable = cancelEnable;
            _WaitTime = 0;
            _method = method;
            this.Timer1.Interval = TimeSpan;
            this.Timer1.Start();
        }

        private void Waiting4Form_Shown(object sender, EventArgs e) {
            _AsyncResult = _method.BeginInvoke(null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */);
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            _WaitTime += TimeSpan;
            this.TimerLabel.Text = $"{_WaitTime / (double)1000} seconds ...";

            if (!this._AsyncResult.IsCompleted) {
                
            } else {
                this.Message = string.Empty;
                this.Close();
            }
        }

        private void Cancelar_Click(object sender, EventArgs e) {
            this.Message = "You have finished the current operation!";
            this.Close();
        }
    }
}
