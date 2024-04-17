using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo tipo de factor
    /// </summary>
    [JsonObject("item")]
    public class CveTipoFactor : ClaveBaseVigenciaSingle {

        public CveTipoFactor() {
        }

        [Description("Clave")]
        [DisplayName("Clave")]
        [JsonProperty("clv")]
        [DataNames("Clave")]
        public string Clave { get; set; }
    }
}