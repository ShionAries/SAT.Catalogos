using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class ConstantOrigin : Abstracts.OriginResource, IOrigin {
        public ConstantOrigin() : base() { }

        /// <summary>
        /// origen
        /// </summary>
        /// <param name="name">nombre o descripcion del recurso</param>
        /// <param name="destinationFilename">nombre del archivo de destino</param>
        /// <param name="lastVersion">fecha de la ultima revisión</param>
        /// <param name="allowUpdate">´permitir la descarga</param>
        public ConstantOrigin(string name, string url, DateTime? lastVersion = null, string destinationFilename = "", bool allowUpdate = true) : base() {
            Name = name;
            Url = url;
            LastVersion = lastVersion;
            AllowUpdate = allowUpdate;

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

        public IOrigin WithDownloadUrl(string downloadUrl) {
            this.DownloadUrl = downloadUrl;
            return this;
        }

        public IOrigin WithLastModified(DateTime? lastModified) {
            this.LastVersion = lastModified; 
            return this;
        }
        #endregion
    }
}
