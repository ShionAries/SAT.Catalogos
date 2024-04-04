using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class ScrapingOrigin : Abstracts.OriginResource, IOriginInterface {

        public ScrapingOrigin() : base() { }

        public ScrapingOrigin(string name, string toScrapUrl, string destinationFilename, string linkText, DateTime? lastVersion = null, string downloadUrl = "", int linkPosition = 0) {
            Name = name;
            Url = toScrapUrl;
            LinkText = linkText;
            LastVersion = lastVersion;
            DestinationFilename = destinationFilename;
            DownloadUrl = downloadUrl;
            LinkPosition = linkPosition;
        }

        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        public override string DownloadUrl { get; set; }

        #region metodos publicos
        public bool HasLastVersion() {
            return this.LastVersion != null;
        }

        public bool HasDownloadUrl() {
            return this.DownloadUrl != "";
        }

        public IOriginInterface WithDownloadUrl(string downloadUrl) {
            this.DownloadUrl = downloadUrl;
            return this;
        }

        public IOriginInterface WithLastModified(DateTime? lastModified) {
            this.LastVersion = lastModified;
            return this;
        }
        #endregion
    }
}
