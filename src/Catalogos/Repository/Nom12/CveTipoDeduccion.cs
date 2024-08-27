using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de tipos de deducciones
    /// </summary>
    [JsonObject("item")]
    public class CveTipoDeduccion : ClaveBaseVigencia, IClaveBaseItem {
    }
}
