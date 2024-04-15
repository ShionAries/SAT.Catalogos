using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo de Periodicidad
    /// </summary>
    [JsonObject("item")]
    public class ClavePeriodicidad : ClaveBaseVigencia, IClaveBaseItem {
        public ClavePeriodicidad() { }
    }
}