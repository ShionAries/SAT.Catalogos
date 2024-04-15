using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catálogo de Países
    /// </summary>
    [JsonObject("item")]
    public class ClaveRetencionPais : ClaveBaseVigencia, IClaveBase {
    }
}
