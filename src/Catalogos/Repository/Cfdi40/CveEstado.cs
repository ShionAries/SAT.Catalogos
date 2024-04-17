using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Nomina: Estados
    /// </summary>
    [JsonObject("item")]
    public class CveEstado : ClaveBaseVigenciaSingle {

        public CveEstado() { }

        /// <summary>
        /// codigo del banco
        /// </summary>
        [DisplayName("Estado")]
        [JsonProperty("clv")]
        [DataNames("Estado")]
        public string Estado { get; set; }

        [DisplayName("País")]
        [JsonProperty("pais")]
        [DataNames("Pais")]
        public string Pais { get; set; }

        /// <summary>
        /// obtener o establecer Nombre del Estado
        /// </summary>
        [DisplayName("Nombre del Estado")]
        [JsonProperty("nom")]
        [DataNames("Nombre")]
        public string Nombre { get; set; }
    }
}