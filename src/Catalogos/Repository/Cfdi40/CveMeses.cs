using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Meses
    /// </summary>
    [JsonObject("item")]
    public class CveMeses : ClaveBaseVigencia, IClaveBaseItem {

    }
}