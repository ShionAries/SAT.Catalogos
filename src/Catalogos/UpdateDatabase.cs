using System;
using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos {
    public class UpdateDatabase : ConfigurationService {

        public event EventHandler<string> NotificationEvent;
        public void OnNotificationEvent(string e) {
            if (this.NotificationEvent != null) {
                this.NotificationEvent(this, e);
            }
        }

        public UpdateDatabase(IConfiguration configuration) : base(configuration) {
            this.Configuration = configuration;
        }

        public int Run() {
            this.OnNotificationEvent("Cargado datos");
            var importer = this.CreateImporter();
            importer.Import(this.Configuration);
            this.OnNotificationEvent("Se terminó correctamente con la actualización de la base de datos");
            return 0;
        }

        public SourcesImporter CreateImporter() {
            return new SourcesImporter();
        }
    }
}
