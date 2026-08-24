using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Bancos {
    [JsonObject("item")]
    public class ClaveBanco : ClaveBaseVigencia, IClaveBaseItem {
        private string razonSocialField;

        [DisplayName("Razon Social")]
        [JsonProperty("rso", Order = 15)]
        public string RazonSocial {
            get {
                return this.razonSocialField;
            }
            set {
                this.razonSocialField = value;
            }
        }
    }
}
