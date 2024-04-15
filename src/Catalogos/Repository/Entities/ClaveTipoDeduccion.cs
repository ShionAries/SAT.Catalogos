using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Nomina: Catalogo de tipos de deducciones
    /// </summary>
    [JsonObject("item")]
    public class ClaveTipoDeduccion : ClaveBaseVigencia, IClaveBaseItem {
    }
}
