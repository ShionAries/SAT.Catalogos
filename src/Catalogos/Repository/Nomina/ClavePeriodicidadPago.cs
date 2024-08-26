using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Nomina: Catalogo de tipos de periodicidad de pago.
    /// </summary>
    [JsonObject("item")]
    public class ClavePeriodicidadPago : ClaveBaseVigencia, IClaveBaseItem {
        public ClavePeriodicidadPago() { }
    }
}
