using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de municipios.
    /// </summary>
    public class CveMunicipio : ClaveBaseVigencia, IClaveBase {
        [DataNames("Estado")]
        public string Estado { get; set; }

        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public string Clave {
            get {
                var numero = int.Parse(base.Clave);
                return numero.ToString("000");
            }
            set {
                base.Clave = int.Parse(value).ToString("000");
            }
        }
    }
}