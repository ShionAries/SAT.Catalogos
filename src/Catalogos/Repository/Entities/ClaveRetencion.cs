using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Retenciones 2.0
    /// </summary>
    [JsonObject("item")]
    public class ClaveRetencion : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveRetencion() {
        }

        /// <summary>
        /// Nombre del complemento
        /// </summary>
        [DataNames("Nombre")]
        public string Nombre { get; set; }
    }
}
