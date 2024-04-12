using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    /// <summary>
    /// item de catalogo (Clave y Descripcion)
    /// </summary>
    [JsonObject("item")]
    public abstract class ClaveBase {
        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public string Clave { get; set; }

        [DisplayName("Descripción")]
        [JsonProperty("desc", Order = 5)]
        [DataNames("Descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// obtener el descriptor de elemento
        /// </summary>
        [JsonIgnore]
        public virtual string Descriptor {
            get { return string.Format("{0}: {1}", Clave, Descripcion); }
        }
    }
}
