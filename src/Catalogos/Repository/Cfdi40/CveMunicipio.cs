using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de municipios.
    /// </summary>
    public class CveMunicipio : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBase {
        [DataNames("Estado")]
        public string Estado { get; set; }

        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public new string Clave {
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