using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    /// <summary>
    /// clase scrap para los orienes
    /// </summary>
    public class ScrapingOrigin : Abstracts.OriginResource, IOrigin {
        /// <summary>
        /// constructor
        /// </summary>
        public ScrapingOrigin() : base() { }

        /// <summary>
        /// origen
        /// </summary>
        /// <param name="name">nombre o descripcion del recurso</param>
        /// <param name="toScrapUrl">url para scraping</param>
        /// <param name="destinationFilename">nombre del archivo de destino</param>
        /// <param name="linkText">texto de busqueda</param>
        /// <param name="lastVersion">fecha de la ultima revisión</param>
        /// <param name="downloadUrl">url de descarga</param>
        /// <param name="linkPosition"></param>
        /// <param name="allowUpdate">´permitir la descarga</param>
        public ScrapingOrigin(string name, string toScrapUrl, string destinationFilename, string linkText, DateTime? lastVersion = null, string downloadUrl = "", bool allowUpdate = true) {
            Name = name;
            Url = toScrapUrl;
            LinkText = linkText;
            LastVersion = lastVersion;
            DestinationFilename = destinationFilename;
            DownloadUrl = downloadUrl;
            AllowUpdate = allowUpdate;
        }

        #region propiedades
        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        public override string DownloadUrl { get; set; }
        #endregion
    }
}
