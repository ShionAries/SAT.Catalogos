using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).
    /// </summary>
    [JsonObject("item")]
    public class CveAduana : ClaveBaseVigencia, IClaveBaseItem {
        public CveAduana() { }
    }
}