using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Tipo de Impuesto
    /// </summary>
    [JsonObject("item")]
    public class CveRetencionTipoImpuesto : ClaveBaseVigencia, IClaveBaseItem {
    }
}
