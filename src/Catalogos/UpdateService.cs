using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// 
    /// </summary>
    public class UpdateService : Scraping.Abstracts.UpdateOrigin {
        public UpdateService() { }

        public List<IOrigin> Run(List<IOrigin> origins) {
            var reviewers = new Reviewers().CreateWithDefaultReviewers();
            var reviews = reviewers.Review(origins);
            var notFoundReviews = reviews.Where(it => it.Status == Scraping.ValueObjects.StatusEnum.NotFound).ToList();
            var notUpdatedReviews = reviews.Where(it => it.Status == Scraping.ValueObjects.StatusEnum.NotUpdated).ToList();
            var upToDateReviews = reviews.Where(it => it.Status == Scraping.ValueObjects.StatusEnum.UpToDate).ToList();

            foreach (var item in upToDateReviews) {
                this.OnNotificationEvent($"El origen {item.Name} desde {item.DownloadUrl} para {item.DestinationFilename} está actualizado");
            }

            foreach (var item in notUpdatedReviews) {
                if (!item.HasLastVersion()) {
                    this.OnNotificationEvent($"El origen {item.Name} desde {item.DownloadUrl} para {item.DestinationFilename} no existe, se descargará");
                } else {
                    this.OnNotificationEvent($"El origen {item.Name} desde {item.DownloadUrl} para {item.DestinationFilename} está desactualizado, la nueva versión tiene fecha {item.LastVersion}");
                }
            }

            foreach (var item in notFoundReviews) {
                this.OnNotificationEvent(string.Format("El origen {0} para {1} no fue encontrado", item.Name, item.DestinationFilename));
            }

            if (notFoundReviews.Count > 0) {
                this.OnNotificationEvent($"No se encontraron {notFoundReviews.Count} orígenes");
            }

            if (upToDateReviews.Count > 0) {
                this.OnNotificationEvent("No existen orígenes para actualizar");
            }
            this.OnNotificationEvent("Descargando ...");
            var upgrader = new Upgrader(reviewers.Gateway, this.WorkingFolder);
            var recentOrigins = upgrader.UpgradeReviews(reviews);
            this.OnNotificationEvent("Actualizando archivo de control de origenes");

            return recentOrigins;
        }
    }
}
