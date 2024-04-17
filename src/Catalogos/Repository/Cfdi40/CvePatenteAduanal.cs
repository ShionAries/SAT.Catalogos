using Newtonsoft.Json;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Patentes Aduanales
    /// </summary>
    [JsonObject("item")]
    public class CvePatenteAduanal : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        public CvePatenteAduanal() { }

        [Description("Clave")]
        [DisplayName("Clave")]
        [JsonProperty("clv")]
        [DataNames("Clave")]
        public string Clave { get; set; }
    }
}