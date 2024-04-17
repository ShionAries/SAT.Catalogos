using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo Objeto de Impuesto
    /// </summary>
    [JsonObject("item")]
    public class CveObjetoImp : ClaveBaseVigencia, IClaveBaseItem {
        public CveObjetoImp() { }
    }
}