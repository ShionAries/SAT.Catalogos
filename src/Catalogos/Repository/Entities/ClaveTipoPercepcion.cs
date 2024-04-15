using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo de tipos de percepciones
    /// </summary>
    [JsonObject("item")]
    public class ClaveTipoPercepcion : ClaveBaseVigencia, IClaveBaseItem {

        public ClaveTipoPercepcion() {
        }
    }
}
