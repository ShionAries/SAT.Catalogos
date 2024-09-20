using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Builder;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    /// <summary>
    /// 
    /// </summary>
    public class UpdateService : Abstracts.UpdateOrigin {
        public UpdateService() {
        }

        public List<IOrigin> Run(List<IOrigin> origins) {
            var reviewers = new Reviewers().CreateWithDefaultReviewers();
            var reviews = reviewers.Review(origins);
            var notFoundReviews = reviews.Where(it => it.Status == ValueObjects.StatusEnum.NotFound).ToList();
            var notUpdatedReviews = reviews.Where(it => it.Status == ValueObjects.StatusEnum.NotUpdated).ToList();
            var upToDateReviews = reviews.Where(it => it.Status == ValueObjects.StatusEnum.UpToDate).ToList();

            var d0 = Create().Update(origins).Execute();


            foreach (var item in upToDateReviews) {
                this.OnNotificationEvent($"El origen {item.Origin.Name} desde {item.Origin.DownloadUrl} para {item.Origin.DestinationFilename} está actualizado");
            }

            foreach (var item in notUpdatedReviews) {
                if (!item.Origin.HasLastVersion()) {
                    this.OnNotificationEvent($"El origen {item.Origin.Name} desde {item.Origin.DownloadUrl} para {item.Origin.DestinationFilename} no existe, se descargará");
                } else {
                    this.OnNotificationEvent($"El origen {item.Origin.Name} desde {item.Origin.DownloadUrl} para {item.Origin.DestinationFilename} está desactualizado, la nueva versión tiene fecha {item.Origin.LastVersion}");
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
            var upgrader = new Upgrader(reviewers.Gateway, this.WorkingFolder);
            var recentOrigins = upgrader.UpgradeReviews(reviews);
            this.OnNotificationEvent("Actualizando archivo de control de origenes");

            return recentOrigins;
        }

        public static IUpdaterServiceBuilder Create() {
            return new UpdaterServiceBuilder();
        }
    }
}
