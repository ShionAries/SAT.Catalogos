using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    /// <summary>
    /// origen del recurso constante
    /// </summary>
    public class ConstantOrigin : Abstracts.OriginResource, IOrigin {
        /// <summary>
        /// constructor
        /// </summary>
        public ConstantOrigin() : base() { }

        /// <summary>
        /// origen
        /// </summary>
        /// <param name="name">nombre o descripcion del recurso</param>
        /// <param name="destinationFilename">nombre del archivo de destino</param>
        /// <param name="lastVersion">fecha de la ultima revisión</param>
        /// <param name="allowUpdate">´permitir la descarga</param>
        public ConstantOrigin(string name, string url, DateTime? lastVersion = null, string destinationFilename = "", bool allowUpdate = true, Type importer = null) : base() {
            Name = name;
            Url = url;
            LastVersion = lastVersion;
            AllowUpdate = allowUpdate;
            Importer = importer;
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
        /// obtener o establecer URL de descarga del archivo, en este caso se sobre escribe la propiedad
        /// porque la liga de la consulta y la descarga de archivo es la misma
        /// </summary>
        public override string DownloadUrl {
            get { return this.Url; }
            set { this.Url = value; }
        }
        #endregion
    }
}
