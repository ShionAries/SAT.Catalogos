using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo Objeto de Impuesto
    /// </summary>
    [JsonObject("item")]
    public class ClaveObjetoImp : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveObjetoImp() { }
    }
}