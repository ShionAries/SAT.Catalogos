using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    [JsonObject("item")]
    public class CveRiesgoPuesto : ClaveBaseVigencia, IClaveBaseItem {
    }
}
