using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Nomina: Catalogo del tipo de origen recurso
    /// </summary>
    [JsonObject("item")]
    public class ClaveOrigenRecurso : ClaveBase, IClaveBase {
        public ClaveOrigenRecurso() { }
    }
}
