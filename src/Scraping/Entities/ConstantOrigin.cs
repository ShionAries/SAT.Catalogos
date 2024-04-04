using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class ConstantOrigin : Abstracts.OriginResource, IOriginInterface {
        public ConstantOrigin() : base() { }

        public ConstantOrigin(string name, string url, DateTime? lastVersion = null, string destinationFilename = "") : base() {
            Name = name;
            Url = url;
            LastVersion = lastVersion;
            if (destinationFilename == "") {
                destinationFilename = System.IO.Path.GetFileName(Url);
            }

            if (destinationFilename != "") {

            }

            if (destinationFilename == "") {

            }
            this.DestinationFilename = destinationFilename;
        }

        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        public override string DownloadUrl {
            get { return this.Url; }
            set { this.Url = value; }
        }

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
