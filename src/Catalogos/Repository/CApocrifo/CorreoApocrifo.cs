using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.CApocrifo {
    public class CorreoApocrifo {
        [JsonProperty("acronym")]
        [DataNames("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("standsFor")]
        [DataNames("standsFor")]
        public string StandsFor { get; set; }
        
        [JsonProperty("descripcion")]
        [DataNames("descripcion")]
        public string Description { get; set; }
    }
}
