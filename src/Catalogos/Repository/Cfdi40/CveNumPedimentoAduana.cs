using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI: Catálogo de números de pedimento operados por aduana y ejercicio.
    /// </summary>
    [JsonObject("item")]
    public class CveNumPedimentoAduana : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        public CveNumPedimentoAduana() { }

        [JsonProperty("clv")]
        [DataNames("Clave")]
        public string Clave { get; set; }

        [JsonProperty("pat")]
        [DataNames("Patente")]
        public string Patente { get; set; }

        [JsonProperty("eje")]
        [DataNames("Ejercicio")]
        public int Ejercicio { get; set; }

        [JsonProperty("can")]
        [DataNames("Cantidad")]
        public int Cantidad { get; set; }
    }
}