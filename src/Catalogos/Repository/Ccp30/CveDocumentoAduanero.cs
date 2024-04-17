using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Documentos Aduaneros
    /// </summary>
    [JsonObject("item")]
    public class CveDocumentoAduanero : ClaveBaseVigencia, IClaveBase { }
}
