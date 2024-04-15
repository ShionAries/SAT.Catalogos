// develop: 070720171730
// purpose: Catálogo de unidades de medida para los conceptos en el CFDI. Catalogo SAT

using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catalogo de monedas
    /// </summary>
    [JsonObject("item")]
    public class ClaveMoneda : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveMoneda() {
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