using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de localidades. 
    /// </summary>
    public class CveLocalidad : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBase {

        public CveLocalidad() : base() { }

        [DataNames("Estado")]
        public string Estado { get; set; }

        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public new string Clave {
            get {
                var numero = int.Parse(base.Clave);
                return numero.ToString("00");
            }
            set {
                base.Clave = int.Parse(value).ToString("00");
            }
        }
    }
}