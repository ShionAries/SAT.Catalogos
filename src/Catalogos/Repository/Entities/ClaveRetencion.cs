/// develop: 260520180023
/// purpose: clase para claves de retencion
using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    [JsonObject("item")]
    public class ClaveRetencion : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveRetencion() {
        }
    }
}
