using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    [JsonObject("item")]
    public class ClaveRiesgoPuesto : ClaveBaseVigencia, IClaveBaseItem
    {
    }
}
