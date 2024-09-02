using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    public class UpdateOrigins : Abstracts.UpdateOrigin {
        /// <summary>
        /// constructor
        /// </summary>
        public UpdateOrigins() : base() {
            this.Origins = new List<IOrigin>();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="workingFolder">ruta de la carpeta de trabajo</param>
        public UpdateOrigins(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") : base(workingFolder) {
            this.Origins = new List<IOrigin>();
        }

        /// <summary>
        /// obtener o establecer origenes
        /// </summary>
        public List<IOrigin> Origins { get; set; }

        public void Read() {
            // cargar datos de los origenes
            this.Origins = new OriginsIO().ReadFile();
            // si es nulo entonces cargamos los datos por default
            if (this.Origins == null) {
                Console.WriteLine("Cargando origenes del local");
                this.Origins = new DumpOrigins().Origins;
            } else {
                this.Write();
            }
        }

        public void Write() {
            var origins = new DumpOrigins().Origins.ToList();
            foreach (var item in origins) {
                try {
                    var search = this.Origins.Where(it => it.Url.ToLower() == item.Url.ToLower()).FirstOrDefault();
                    if (search == null) {
                        this.Origins.Add(item);
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Run() {
            this.Read();

            this.ResourcesGateway = new ResourcesGateway();
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
            var upgrader = new Upgrader(this.ResourcesGateway, this.WorkingFolder);
            var recentOrigins = upgrader.UpgradeReviews(reviews);
            this.OnNotificationEvent("Actualizando archivo de control de origenes");
            new OriginsIO().WriteFile(recentOrigins);
        }
    }
}
