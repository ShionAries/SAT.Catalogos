using System;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    /// <summary>
    /// clase abstracta de origen del recurso
    /// </summary>
    public abstract class OriginResource : IOrigin {
        #region declaraciones
        private DateTime? _LastVersion;
        #endregion

        #region propiedades
        /// <summary>
        /// obtener o establecer nombre del origen
        /// </summary>
        [DisplayName("Recurso")]
        public string Name { get; set; }

        /// <summary>
        /// obtener o establecer URL de consulta de la pagina
        /// </summary>
        [DisplayName("URL")]
        public string Url { get; set; }

        /// <summary>
        /// obtener o establecer fecha de la ultima actualizacion del catalogo
        /// </summary>
        [DisplayName("Actualizado")]
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
        [DisplayName("URL de Descarga")]
        public abstract string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        public string DestinationFilename { get; set; }

        /// <summary>
        /// obtener o establecer texto de referencia para la busqueda del link de descarga
        /// </summary>
        [DisplayName("Búsqueda por")]
        public string LinkText { get; set; }

        /// <summary>
        /// obtener o establecer si es permitida la actualizacion
        /// </summary>
        [DisplayName("Permitir")]
        public bool AllowUpdate { get; set; }

        [Browsable(false)]
        [System.Xml.Serialization.XmlIgnore]
        public int LinkPosition { get; set; }
        #endregion


        #region metodos publicos
        public virtual bool HasLastVersion() {
            return this.LastVersion != null;
        }

        public virtual bool HasDownloadUrl() {
            return this.DownloadUrl != "";
        }
        #endregion

        #region builder
        public virtual IOrigin WithDownloadUrl(string downloadUrl) {
            this.DownloadUrl = downloadUrl;
            return this;
        }

        public virtual IOrigin WithLastModified(DateTime? lastModified) {
            this.LastVersion = lastModified;
            return this;
        }
        #endregion
    }
}
