using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// clase para actualizacion
    /// </summary>
    internal class Upgrader {
        #region declaraciones
        private readonly IResourcesGateway gateway;
        private readonly string destinationPath;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gateway"></param>
        /// <param name="destinationPath">archivo destino</param>
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

        /// <summary>
        /// revision de actualizacion
        /// </summary>
        /// <param name="origin">IOrigin</param>
        public IOrigin UpgradeReview(IOrigin origin) {
            var destination = this.BuildPath(origin.DestinationFilename);
            if (!(origin.Status == ValueObjects.StatusEnum.NotUpdated)) {
                return origin;
            }
            Console.WriteLine($"Actualizando {origin.Name} desde {origin.DownloadUrl} en {destination}");
            var urlResponse = this.gateway.Get(origin.DownloadUrl, destination);
            return origin.WithLastModified(urlResponse.LastModified);
        }
    }
}
