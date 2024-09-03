using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    public class UpdateService : Abstracts.UpdateOrigin {
        public UpdateService() {
            this.ResourcesGateway = new ResourcesGateway();
        }

        public List<IOrigin> Run(List<IOrigin> origins) {
            this.ResourcesGateway = new ResourcesGateway();
            var reviewers = new Reviewers().CreateWithDefaultReviewers(this.ResourcesGateway);
            var reviews = reviewers.Review(origins);
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
            var upgrader = new Upgrader(this.ResourcesGateway, this.WorkingFolder);
            var recentOrigins = upgrader.UpgradeReviews(reviews);
            this.OnNotificationEvent("Actualizando archivo de control de origenes");
            
            return recentOrigins;
        }
    }
}
