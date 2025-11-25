using System;
using System.Windows.Forms;

namespace Tester.Forms {
    public partial class WaitWindowGUIForm : Form {
        public WaitWindowGUIForm(WaitWindow parent) {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            this._Parent = parent;

            //	Position the window in the top right of the main screen.
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom / 2 + 32;
            this.Left = Screen.PrimaryScreen.WorkingArea.Right / 2 - this.Width / 2;// - 32;
        }

        protected WaitWindow _Parent;
        private delegate T FunctionInvoker<T>();
        internal object _Result;
        internal Exception _Error;
        protected IAsyncResult threadResult;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            base.OnPaint(e);
            //	Paint a 3D border
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Raised);
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);

            //   Create Delegate
            FunctionInvoker<object> threadController = new FunctionInvoker<object>(this.DoWork);

            //   Execute on secondary thread.
            this.threadResult = threadController.BeginInvoke(this.WorkComplete, threadController);
        }

        internal object DoWork() {
            //	Invoke the worker method and return any results.
            WaitWindowEventArgs e = new WaitWindowEventArgs(this._Parent, this._Parent._Args);
            if ((this._Parent._WorkerMethod != null)) {
                this._Parent._WorkerMethod(this, e);
            }
            return e.Result;
        }

        private void WorkComplete(IAsyncResult results) {
            if (!this.IsDisposed) {
                if (this.InvokeRequired) {
                    this.Invoke(new WaitWindow.MethodInvoker<IAsyncResult>(this.WorkComplete), results);
                } else {
                    //	Capture the result
                    try {
                        this._Result = ((FunctionInvoker<object>)results.AsyncState).EndInvoke(results);
                    } catch (Exception ex) {
                        //	Grab the Exception for rethrowing after the WaitWindow has closed.
                        this._Error = ex;
                    }
                    this.Close();
                }
            }
        }

        internal void SetMessage(string message) {
           this.MessageLabel.Text = message;
        }

        internal void Cancel() {
            this.Invoke(new MethodInvoker(this.Close), null);
        }

    }
}
