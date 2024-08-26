using System.ComponentModel;
using System.Xml.Serialization;
using Jaeger.Catalogos.Contracts;
using Newtonsoft.Json;

namespace Jaeger.Catalogos.Entities {
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveBancoRFC : ClaveBaseVigencia, IClaveBaseItem {
        private string razonSocialField;
        private string rfcField;

        [DisplayName("Razón Social")]
        [JsonProperty("rso")]
        [XmlAttribute("razonSocial")]
        public string RazonSocial {
            get {
                return this.razonSocialField;
            }
            set {
                this.razonSocialField = value;
                this.OnPropertyChanged();
            }
        }

        [JsonProperty("rfc")]
        [XmlAttribute("rfc")]
        public string RFC {
            get {
                return this.rfcField;
            }
            set {
                this.rfcField = value;
                this.OnPropertyChanged();
            }
        }
    }
}