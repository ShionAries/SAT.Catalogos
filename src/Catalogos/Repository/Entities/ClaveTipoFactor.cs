using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catalogo tipo de factor
    /// </summary>
    [JsonObject("item")]
    public class ClaveTipoFactor : ClaveBaseVigenciaSingle {

        public ClaveTipoFactor() {
        }

        [Description("Clave")]
        [DisplayName("Clave")]
        [JsonProperty("clv")]
        [DataNames("Clave")]
        public string Clave { get; set; }
    }
}