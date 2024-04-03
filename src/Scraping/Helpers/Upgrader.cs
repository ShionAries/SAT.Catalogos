using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    internal class Upgrader {
        public const string DEFAULT_ORIGINS_FILENAME = "origins.xml";
        private IResourcesGatewayInterface gateway;
        private string destinationPath;
        public Upgrader(IResourcesGatewayInterface gateway, string destinationPath) {
            this.gateway = gateway;
            this.destinationPath = destinationPath;
        }

        protected string buildPath(string filename) {
            return System.IO.Path.Combine(destinationPath, filename);
        }

        public IOriginInterface upgradeReview(Review review) {
            var origin = review.Origin;
            var destination = this.buildPath(origin.DestinationFilename);
            if (!review.Status.isNotUpdated()) {
                return origin;
            }
            Console.WriteLine($"Actualizando {origin.Name} desde {origin.DownloadUrl} en {destination}");
            var urlResponse = this.gateway.Get(origin.DownloadUrl, destination);
            return origin.withLastModified(urlResponse.LastModified);
        }

        public List<IOriginInterface> upgradeReviews(List<Review> reviews) {
            var origins = new List<IOriginInterface>();
            foreach (Review review in reviews) {
                origins.Add(upgradeReview(review));
            }
            return origins;
        }
    }
}
