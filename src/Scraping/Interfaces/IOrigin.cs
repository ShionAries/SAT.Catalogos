using System;
using System.ComponentModel;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    /// <summary>
    /// interface de origen de datos
    /// </summary>
    public interface IOrigin {
        #region propiedades
        /// <summary>
        /// obtener o establecer nombre del origen
        /// </summary>
        [DisplayName("Recurso")]
        string Name { get; set; }

        /// <summary>
        /// obtener o establecer URL de consulta de la pagina
        /// </summary>
        [DisplayName("URL de Origen")]
        string Url { get; set; }

        /// <summary>
        /// obtener o establecer fecha de la ultima actualizacion del catalogo
        /// </summary>
        [DisplayName("Actualización")]
        DateTime? LastVersion { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo de descarga
        /// </summary>
        [DisplayName("Archivo Destino")]
        string DestinationFilename { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Buscar por")]
        string LinkText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        int LinkPosition { get; set; }

        /// <summary>
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        [DisplayName("URL de Descarga")]
        string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer si el origen es actualizable
        /// </summary>
        [DisplayName("Permitir")]
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
