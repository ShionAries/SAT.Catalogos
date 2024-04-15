using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// tipo de impuestos para retenciones
    /// </summary>
    [JsonObject("item")]
    public class ClaveRetencionTipoImpuesto : ClaveBaseVigencia, IClaveBaseItem {
    }
}
