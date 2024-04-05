using System;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    public interface IOriginInterface {
        /// <summary>
        /// obtener o establecer nombre del origen
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// obtener o establecer URL de consulta de la pagina
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// obtener o establecer fecha de la ultima actualizacion del catalogo
        /// </summary>
        DateTime? LastVersion { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        string DestinationFilename { get; set; }
        
        string LinkText { get; set; }
        
        int LinkPosition { get; set; }
        
        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer si el origen es actualizable
        /// </summary>
        bool AllowUpdate { get; set; }

        IOriginInterface WithDownloadUrl(string downloadUrl);
        
        IOriginInterface WithLastModified(DateTime? lastModified);
        
        bool HasLastVersion();
        
        bool HasDownloadUrl();
    }
}
