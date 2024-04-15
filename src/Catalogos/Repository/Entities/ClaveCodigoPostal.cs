using Newtonsoft.Json;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo de codigos postales
    /// </summary>
    [JsonObject]
    public class ClaveCodigoPostal : ClaveBaseVigenciaSingle {

        public ClaveCodigoPostal() {
            this.Clave = string.Empty;
            this.Estado = string.Empty;
            this.Municipio = string.Empty;
            this.Localidad = string.Empty;
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