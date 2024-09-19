using System.ComponentModel;

namespace Jaeger.SAT.Catalogos.Scraping.ValueObjects {
    /// <summary>
    /// enumeracion de status del origen
    /// </summary>
    public enum StatusEnum {
        [Description("Actualizado")]
        UpToDate,
        [Description("No Encontrado")]
        NotFound,
        [Description("No Actualizado")]
        NotUpdated
    }
}
