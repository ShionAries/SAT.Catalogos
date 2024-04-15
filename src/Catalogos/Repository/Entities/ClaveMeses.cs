using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo de Meses
    /// </summary>
    [JsonObject("item")]
    public class ClaveMeses : ClaveBaseVigencia, IClaveBaseItem {

    }
}