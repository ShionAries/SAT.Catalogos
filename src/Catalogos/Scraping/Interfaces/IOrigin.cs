using System;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    /// <summary>
    /// interface de origen de datos
    /// </summary>
    public interface IOrigin {
        #region propiedades
        /// <summary>
        /// obtener o establecer nombre del origen
        /// </summary>
        [DisplayName("Nombre del recurso")]
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
        /// obtener o establecer URL de descarga del archivo
        /// </summary>
        [DisplayName("URL de Descarga")]
        string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer si el origen es actualizable
        /// </summary>
        [DisplayName("Permitir")]
        bool AllowUpdate { get; set; }

        [DisplayName("Importador")]
        Type Importer { get; set; }

        /// <summary>
        /// obtener o establecer status del origen de recurso
        /// </summary>
        [DisplayName("Status")]
        StatusEnum Status { get; set; }
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
