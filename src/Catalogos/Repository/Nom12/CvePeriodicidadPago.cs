using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de tipos de periodicidad de pago.
    /// </summary>
    [JsonObject("item")]
    public class CvePeriodicidadPago : ClaveBaseVigencia, IClaveBaseItem {
        public CvePeriodicidadPago() { }
    }
}
