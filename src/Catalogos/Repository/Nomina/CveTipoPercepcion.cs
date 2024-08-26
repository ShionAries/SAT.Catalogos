using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Nomina: Catalogo de tipos de percepciones
    /// </summary>
    [JsonObject("item")]
    public class CveTipoPercepcion : ClaveBaseVigencia, IClaveBaseItem {

        public CveTipoPercepcion() {
        }
    }
}
