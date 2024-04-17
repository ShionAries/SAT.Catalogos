using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0: Catalogo de tipos de relacion entre CFDI
    /// </summary>
    [JsonObject("item")]
    public class CveTipoRelacionCFDI : ClaveBaseVigencia, IClaveBaseItem {
        public CveTipoRelacionCFDI() { }
    }
}