using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Retenciones
    /// </summary>
    [JsonObject("item")]
    public class CveRetencion : ClaveBaseVigencia, IClaveBaseItem {
        public CveRetencion() { }

        /// <summary>
        /// Nombre del complemento
        /// </summary>
        [DataNames("Nombre")]
        public string Nombre { get; set; }
    }
}
