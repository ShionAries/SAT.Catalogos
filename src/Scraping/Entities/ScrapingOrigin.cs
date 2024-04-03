using System;
using System.Runtime.Serialization;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    [DataContract]
    public class ScrapingOrigin : IOriginInterface {
        private DateTime? _LastVersion;

        public ScrapingOrigin(string name, string toScrapUrl, string destinationFilename, string linkText, DateTime? lastVersion = null, string downloadUrl = "", int linkPosition = 0) {
            Name = name;
            Url = toScrapUrl;
            LinkText = linkText;
            LastVersion = lastVersion;
            DestinationFilename = destinationFilename;
            DownloadUrl = downloadUrl;
            LinkPosition = linkPosition;
        }

        #region propiedades
        /// <summary>
        /// obtener o establecer nombre del origen
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// obtener o establecer URL de consulta de la pagina
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// obtener o establecer texto clave para la busqueda del link de descarga
        /// </summary>
        [DataMember]
        public string LinkText { get; set; }

        /// <summary>
        /// obtener o establecer fecha de la ultima actualizacion del catalogo
        /// </summary>
        [DataMember]
        public DateTime? LastVersion {
            get {
                if (_LastVersion > new DateTime(1989, 1, 1))
                    return _LastVersion;
                return null;
            }
            set { _LastVersion = value; }
        }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        [DataMember]
        public string DestinationFilename { get; set; }

        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        [DataMember]
        public string DownloadUrl { get; set; }
        

        [DataMember]
        public int LinkPosition { get; set; }
        #endregion

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

        public IOriginInterface withLastModified(DateTime? lastModified) {
            this.LastVersion = lastModified;
            return this;
        }
        #endregion
    }
}
