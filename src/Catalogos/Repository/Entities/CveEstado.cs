using System.ComponentModel;
using System.Xml.Serialization;
using Jaeger.Catalogos.Contracts;
using Newtonsoft.Json;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catalogo de Carta Porte: Estados
    /// </summary>
    [JsonObject("item")]
    [XmlRoot("item")]
    public class CveEstado : ClaveBaseVigencia, IClaveBase {
        private string descripcionField;

        public CveEstado() {
        }

        [DisplayName("País")]
        [JsonProperty("pais")]
        [XmlAttribute("pais")]

        public string ClavePais {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.OnPropertyChanged();
            }
        }
    }
}