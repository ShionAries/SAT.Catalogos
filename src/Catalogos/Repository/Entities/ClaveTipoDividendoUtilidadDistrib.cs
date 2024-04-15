using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    [JsonObject("item")]
    public class ClaveTipoDividendoUtilidadDistrib : ClaveBaseVigencia, IClaveBaseItem {
    }
}
