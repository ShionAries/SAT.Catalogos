using System;
using System.Runtime.Serialization;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    [DataContract]
    public class ConstantOrigin : IOriginInterface {
        private DateTime? _LastVersion;

        public ConstantOrigin(string name, string url, DateTime? lastVersion = null, string destinationFilename = "") {
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
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        [DataMember] 
        public string DownloadUrl {
            get { return this.Url; }
            set { this.Url = value; }
        }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        [DataMember] 
        public string DestinationFilename { get; set; }
        
        public string LinkText { get; set; }

        public int LinkPosition { get; set; }
        #endregion

        #region metodos publicos
        public bool HasDownloadUrl() {
            return this.DownloadUrl != "";
        }

        public bool HasLastVersion() {
            return this.LastVersion != null;
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
