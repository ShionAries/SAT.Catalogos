using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    public class UpdateOrigins {
        private List<IOriginInterface> Origins = new List<IOriginInterface>();
        private WebResourcesGateway resourcesGateway;
        private string getWorkingFolder;

        public UpdateOrigins() {
            this.getWorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
        }

        public void Run() {
            this.Origins = OriginsIO.DeSerialize();// new DumpOrigins().Origins;
            this.resourcesGateway = new WebResourcesGateway();
            var reviewers = new Reviewers().CreateWithDefaultReviewers(this.resourcesGateway);
            var reviews = reviewers.Review(Origins);
            var notFoundReviews = reviews.Where(it => it.Status.isNotFound()).ToList();
            var notUpdatedReviews = reviews.Where(it => it.Status.isNotUpdated()).ToList();
            var upToDateReviews = reviews.Where(it => it.Status.isUptodate()).ToList();

            foreach (var item in upToDateReviews) {
                Console.WriteLine(string.Format("El origen {0} desde {1} para {2}s está actualizado", item.Origin.Name, item.Origin.DownloadUrl, item.Origin.DestinationFilename));
            }

            foreach (var item in notUpdatedReviews) {
                if (!item.Origin.HasLastVersion()) {
                    Console.WriteLine(string.Format("El origen {0} desde {1} para {2} no existe, se descargará", item.Origin.Name, item.Origin.DownloadUrl, item.Origin.DestinationFilename));
                } else {
                    Console.WriteLine(string.Format("El origen {0} desde {1} para {2} está desactualizado, la nueva versión tiene fecha {3}", item.Origin.Name, item.Origin.DownloadUrl, item.Origin.DestinationFilename, item.Origin.LastVersion));
                }
            }

            foreach (var item in notFoundReviews) {
                Console.WriteLine(string.Format("El origen {0} para {1} no fue encontrado", item.Origin.Name, item.Origin.DestinationFilename));
            }

            if (notFoundReviews.Count > 0) {
                Console.WriteLine($"No se encontraron {notFoundReviews.Count} orígenes");
            }

            if (upToDateReviews.Count>0) {
                Console.WriteLine("No existen orígenes para actualizar");
            }

            var upgrader = new Upgrader(this.resourcesGateway, this.getWorkingFolder);
            var recentOrigins = upgrader.upgradeReviews(reviews);
            OriginsIO.Serialize(recentOrigins);
        }
    }
}
