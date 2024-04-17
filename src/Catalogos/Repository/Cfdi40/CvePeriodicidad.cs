using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Periodicidad CFDI
    /// </summary>
    [JsonObject("item")]
    public class CvePeriodicidad : ClaveBaseVigencia, IClaveBaseItem {
        public CvePeriodicidad() { }
    }
}