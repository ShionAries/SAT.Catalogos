using System;
using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos {
    public class UpdateDatabase {
        private string _SourceFolder;
        protected Helpers.ILogger _Logger;
        public event EventHandler<string> NotificationEvent;
        public void OnNotificationEvent(string e) {
            if (this.NotificationEvent != null) {
                this.NotificationEvent(this, e);
            }
        }

        public UpdateDatabase(string sourceFolder) {
            this.SourceFolder = sourceFolder;
            this._Logger = new Helpers.Logger();
        }

        /// <summary>
        /// obtener o establecer la carpeta donde estan los archivos de origen
        /// </summary>
        public string SourceFolder {
            get { return this._SourceFolder; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Invalid source catalog: empty string received");
                }

                if (!Helpers.DirectoryService.IsDirectory(value)) {
                    throw new ArgumentException("Invalid source catalog: is not a directory");
                }
                this._SourceFolder = value;
            }
        }

        public int Run() {
            this.OnNotificationEvent("Cargado datos");
            var importer = this.CreateImporter();
            importer.Import(this.SourceFolder, this._Logger);
            this.OnNotificationEvent("Se terminó correctamente con la actualización de la base de datos");
            this._Logger.Info("Se terminó correctamente con la actualización de la base de datos");
            return 0;
        }

        public SourcesImporter CreateImporter() {
            return new SourcesImporter();
        }
    }
}
