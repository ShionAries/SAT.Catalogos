using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo de tipos de periodicidad de pago.
    /// </summary>
    [JsonObject("item")]
    public class ClavePeriodicidadPago : ClaveBaseVigencia, IClaveBaseItem {

    }
}
