// develop: 161120162142
// purpose: clase para contener elemento del catalogo de bancos SAT
// rev.: 180120182344: actulizamos la clase
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de bancos SAT
    /// </summary>
    [JsonObject("item")]
    public class CveBanco : ClaveBaseVigencia, IClaveBaseItem {

        public CveBanco() : base() {
            this.RazonSocial = string.Empty;
        }

        [DisplayName("Razon Social")]
        [JsonProperty("rso", Order = 15)]
        [DataNames("RazonSocial")]
        public string RazonSocial { get; set; }

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