using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    internal class Upgrader {
        private readonly IResourcesGatewayInterface gateway;
        private readonly string destinationPath;

        public Upgrader(IResourcesGatewayInterface gateway, string destinationPath) {
            this.gateway = gateway;
            this.destinationPath = destinationPath;
        }

        protected string BuildPath(string filename) {
            return System.IO.Path.Combine(destinationPath, filename);
        }

        public IOriginInterface UpgradeReview(Review review) {
            var origin = review.Origin;
            var destination = this.BuildPath(origin.DestinationFilename);
            if (!review.Status.IsNotUpdated()) {
                return origin;
            }
            Console.WriteLine($"Actualizando {origin.Name} desde {origin.DownloadUrl} en {destination}");
            var urlResponse = this.gateway.Get(origin.DownloadUrl, destination);
            return origin.WithLastModified(urlResponse.LastModified);
        }

        public List<IOriginInterface> UpgradeReviews(List<Review> reviews) {
            var origins = new List<IOriginInterface>();
            foreach (Review review in reviews) {
                origins.Add(UpgradeReview(review));
            }
            return origins;
        }
    }
}
