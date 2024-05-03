using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// clase para actualizacion
    /// </summary>
    internal class Upgrader {
        private readonly IResourcesGateway gateway;
        private readonly string destinationPath;

        public Upgrader(IResourcesGateway gateway, string destinationPath) {
            this.gateway = gateway;
            this.destinationPath = destinationPath;
        }

        /// <summary>
        /// creador de ruta
        /// </summary>
        /// <param name="filename">nomrbe del archivo</param>
        /// <returns>path</returns>
        protected string BuildPath(string filename) {
            return System.IO.Path.Combine(destinationPath, filename);
        }

        public IOrigin UpgradeReview(Review review) {
            var origin = review.Origin;
            var destination = this.BuildPath(origin.DestinationFilename);
            if (!review.Status.IsNotUpdated()) {
                return origin;
            }
            Console.WriteLine($"Actualizando {origin.Name} desde {origin.DownloadUrl} en {destination}");
            var urlResponse = this.gateway.Get(origin.DownloadUrl, destination);
            return origin.WithLastModified(urlResponse.LastModified);
        }

        public List<IOrigin> UpgradeReviews(List<Review> reviews) {
            var origins = new List<IOrigin>();
            foreach (Review review in reviews) {
                origins.Add(UpgradeReview(review));
            }
            return origins;
        }
    }
}
