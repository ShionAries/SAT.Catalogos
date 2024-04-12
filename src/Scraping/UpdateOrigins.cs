using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    //custom delegate
    public delegate void DelEventHandler();

    public class UpdateOrigins {
        protected List<IOrigin> Origins;
        protected IResourcesGateway ResourcesGateway;
        protected internal string getWorkingFolder;

        public event EventHandler<string> NotificationEvent;
        public void OnNotificationEvent(string e) {
            if (this.NotificationEvent != null) {
                this.NotificationEvent(this, e);
            }
        }

        public UpdateOrigins(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            this.getWorkingFolder = workingFolder;
            this.Origins = new List<IOrigin>();
        }

        public void Run() {
            // cargar datos de los origenes
            this.Origins = new OriginsIO().ReadFile();
            // si es nulo entonces cargamos los datos por default
            if (this.Origins == null) {
                Console.WriteLine("Cargando origenes del local");
                this.Origins = new DumpOrigins().Origins;
            }

            this.ResourcesGateway = new WebResourcesGateway();
            var reviewers = new Reviewers().CreateWithDefaultReviewers(this.ResourcesGateway);
            var reviews = reviewers.Review(Origins);
            var notFoundReviews = reviews.Where(it => it.Status.IsNotFound()).ToList();
            var notUpdatedReviews = reviews.Where(it => it.Status.IsNotUpdated()).ToList();
            var upToDateReviews = reviews.Where(it => it.Status.IsUptodate()).ToList();

            foreach (var item in upToDateReviews) {
                this.OnNotificationEvent(string.Format("El origen {0} desde {1} para {2} está actualizado", item.Origin.Name, item.Origin.DownloadUrl, item.Origin.DestinationFilename));
            }

            foreach (var item in notUpdatedReviews) {
                if (!item.Origin.HasLastVersion()) {
                    this.OnNotificationEvent(string.Format("El origen {0} desde {1} para {2} no existe, se descargará", item.Origin.Name, item.Origin.DownloadUrl, item.Origin.DestinationFilename));
                } else {
                    this.OnNotificationEvent(string.Format("El origen {0} desde {1} para {2} está desactualizado, la nueva versión tiene fecha {3}", item.Origin.Name, item.Origin.DownloadUrl, item.Origin.DestinationFilename, item.Origin.LastVersion));
                }
            }

            foreach (var item in notFoundReviews) {
                this.OnNotificationEvent(string.Format("El origen {0} para {1} no fue encontrado", item.Origin.Name, item.Origin.DestinationFilename));
            }

            if (notFoundReviews.Count > 0) {
                this.OnNotificationEvent($"No se encontraron {notFoundReviews.Count} orígenes");
            }

            if (upToDateReviews.Count > 0) {
                this.OnNotificationEvent("No existen orígenes para actualizar");
            }
            this.OnNotificationEvent("Descargando ...");
            var upgrader = new Upgrader(this.ResourcesGateway, this.getWorkingFolder);
            this.OnNotificationEvent("Actualizando archivo de control de origenes");
            var recentOrigins = upgrader.UpgradeReviews(reviews);
            new OriginsIO().WriteFile(recentOrigins);
        }
    }
}
