using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// tipo de impuestos para retenciones
    /// </summary>
    [JsonObject("item")]
    public class ClaveRetencionTipoImpuesto : ClaveBaseVigencia, IClaveBaseItem {
    }
}
