using System;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    /// <summary>
    /// interface de origen de datos
    /// </summary>
    public interface IOrigin {
        #region propiedades
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
        
        /// <summary>
        /// 
        /// </summary>
        string LinkText { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        int LinkPosition { get; set; }
        
        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer si el origen es actualizable
        /// </summary>
        bool AllowUpdate { get; set; }
        #endregion

        #region metodos publicos
        bool HasLastVersion();
        
        bool HasDownloadUrl();
        #endregion

        #region builder
        IOrigin WithDownloadUrl(string downloadUrl);
        
        IOrigin WithLastModified(DateTime? lastModified);
        #endregion
    }
}
