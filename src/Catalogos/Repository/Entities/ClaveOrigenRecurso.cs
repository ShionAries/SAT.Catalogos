using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo del tipo de origen recurso
    /// </summary>
    [JsonObject("item")]
    public class ClaveOrigenRecurso : ClaveBase, IClaveBase {
        public ClaveOrigenRecurso() {
        }
    }
}
