using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo del tipo de origen recurso
    /// </summary>
    [JsonObject("item")]
    public class CveOrigenRecurso : ClaveBase, IClaveBase {
        public CveOrigenRecurso() { }
    }
}
