using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de monedas
    /// </summary>
    [JsonObject("item")]
    public class CveMoneda : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBaseItem {
        public CveMoneda() {
        }

        [DisplayName("Decimales")]
        [JsonProperty("dec")]
        [DataNames("Decimales")]
        public int Decimales { get; set; }

        [DisplayName("Porcentaje variación")]
        [JsonProperty("var")]
        [DataNames("PorcentajeVariacion")]
        public int? PorcentajeVariacion { get; set; }
    }
}