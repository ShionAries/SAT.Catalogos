using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    //custom delegate
    //public delegate void DelEventHandler();

    public abstract class UpdateOrigin {
        protected IResourcesGateway ResourcesGateway;
        public event EventHandler<string> NotificationEvent;

        public void OnNotificationEvent(string e) {
            if (this.NotificationEvent != null) {
                this.NotificationEvent(this, e);
            }
        }

        public UpdateOrigin() {
            this.WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
        }

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
