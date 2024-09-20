using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    //custom delegate
    //public delegate void DelEventHandler();
    /// <summary>
    /// clase abstracta
    /// </summary>
    public abstract class UpdateOrigin {
        
        public event EventHandler<string> NotificationEvent;

        public void OnNotificationEvent(string e) {
            if (this.NotificationEvent != null) {
                this.NotificationEvent(this, e);
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public UpdateOrigin() {
            this.WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="workingFolder">carpeta temporal de trabajo</param>
        public UpdateOrigin(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            this.WorkingFolder = workingFolder;
        }

        /// <summary>
        /// obtener o establecer carpeta de trabajo
        /// </summary>
        public string WorkingFolder { get; set; }

        #region builder
        public UpdateOrigin WithWorkingFolder(string workingFilder) {
            this.WorkingFolder = workingFilder;
            return this;
        }
        #endregion
    }
}
