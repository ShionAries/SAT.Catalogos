using Newtonsoft.Json;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de codigos postales
    /// </summary>
    [JsonObject]
    public class CveCodigoPostal : ClaveBaseVigenciaSingle {

        public CveCodigoPostal() {
            Clave = string.Empty;
            Estado = string.Empty;
            Municipio = string.Empty;
            Localidad = string.Empty;
        }

        [DisplayName("CodigoPostal")]
        [JsonProperty("cod")]
        [DataNames("Clave")]
        public string Clave { get; set; }

        [DisplayName("Estado")]
        [JsonProperty("est")]
        [DataNames("Estado")]
        public string Estado { get; set; }

        [DisplayName("Municipio")]
        [JsonProperty("mun")]
        [DataNames("Municipio")]
        public string Municipio { get; set; }

        [DisplayName("Localidad")]
        [JsonProperty("loc")]
        [DataNames("Localidad")]
        public string Localidad { get; set; }

        /// <summary>
        /// Estímulo Franja Fronteriza
        /// </summary>
        [DisplayName("Estímulo Franja Fronteriza")]
        [JsonProperty("esti")]
        [DataNames("Estimulo")]
        public int Estimulo { get; set; }
    }
}