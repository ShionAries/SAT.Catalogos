using System.ComponentModel;

namespace Jaeger.SAT.Catalogos.Scraping.ValueObjects {
    /// <summary>
    /// enumeracion de status del origen
    /// </summary>
    public enum StatusEnum {
        /// <summary>
        /// Actualizado
        /// </summary>
        [Description("Actualizado")]
        UpToDate,
        /// <summary>
        /// No Encontado
        /// </summary>
        [Description("No Encontrado")]
        NotFound,
        /// <summary>
        /// No Actualizado
        /// </summary>
        [Description("No Actualizado")]
        NotUpdated
    }
}
