using System.Runtime.Serialization;
using System;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    [DataContract]
    public abstract class OriginResource {
        private DateTime? _LastVersion;

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
        public abstract string DownloadUrl {  get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        [DataMember]
        public string DestinationFilename { get; set; }

        public string LinkText { get; set; }

        public int LinkPosition { get; set; }
        #endregion
    }
}
