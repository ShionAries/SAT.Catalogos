using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Tipo de Dividendo o utilidad distribuida
    /// </summary>
    [JsonObject("item")]
    public class CveTipoDividendoUtilidadDistrib : ClaveBaseVigencia, IClaveBaseItem {
    }
}
