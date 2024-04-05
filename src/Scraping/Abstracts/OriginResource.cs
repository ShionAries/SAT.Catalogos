using System;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    public abstract class OriginResource {
        private DateTime? _LastVersion;

        #region propiedades
        /// <summary>
        /// obtener o establecer nombre del origen
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// obtener o establecer URL de consulta de la pagina
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// obtener o establecer fecha de la ultima actualizacion del catalogo
        /// </summary>
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
        public abstract string DownloadUrl {  get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        public string DestinationFilename { get; set; }

        public string LinkText { get; set; }

        public bool AllowUpdate {  get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public int LinkPosition { get; set; }
        #endregion
    }
}
