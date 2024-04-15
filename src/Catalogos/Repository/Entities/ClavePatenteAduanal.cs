using Newtonsoft.Json;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    [JsonObject("item")]
    public class ClavePatenteAduanal : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        public ClavePatenteAduanal() { }

        [Description("Clave")]
        [DisplayName("Clave")]
        [JsonProperty("clv")]
        [DataNames("Clave")]
        public string Clave { get; set; }
    }
}