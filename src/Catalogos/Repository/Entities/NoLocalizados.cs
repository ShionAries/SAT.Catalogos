using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    [JsonObject("item")]
    public class NoLocalizados {
        public NoLocalizados() { }

        /// <summary>
        /// obtener o establecer RFC
        /// </summary>
        [JsonProperty("RFC")]
        [DataNames("RFC")]
        public string RFC { get; set; }

        /// <summary>
        /// obtener o establecer nombreo o razon social
        /// </summary>
        [JsonProperty("RazonSocial")]
        [DataNames("RazonSocial")]
        public string RazonSocial { get; set; }

        /// <summary>
        /// obtener o establecer tipo de persona M = Moral, F = Fisica
        /// </summary>
        [JsonProperty("TipoPersona")]
        [DataNames("TipoPersona")]
        public string TipoPersona { get; set; }

        /// <summary>
        /// obtener o establecer supuesto
        /// </summary>
        [JsonProperty("Supuesto")]
        [DataNames("Supuesto")]
        public string Supuesto { get; set; }

        /// <summary>
        /// obtener o establecer Fecha de Primera Publicacion
        /// </summary>
        [JsonProperty("FechaPrimeraPublicacion")]
        [DataNames("FechaPrimeraPublicacion")]
        public string FechaPrimeraPublicacion { get; set; }

        /// <summary>
        /// obtener o establecer entidad federativa
        /// </summary>
        [JsonProperty("EntidadFederativa")]
        [DataNames("EntidadFederativa")]
        public string EntidadFederativa { get; set; }
    }
}
