using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    [JsonObject("item")]
    public class TipoConcepto : ClaveBase {
        private string tipo;
        private decimal iva;
        private string cuentaContable;

        [DisplayName("Tipo")]
        [JsonProperty("tp")]
        [XmlAttribute("Tipo")]
        public string Tipo {
            get { return this.tipo; }
            set { this.tipo = value;
                this.OnPropertyChanged();
            }
        }

        [DisplayName("iva")]
        [JsonProperty("iva")]
        [XmlAttribute("iva")]
        public decimal IVA {
            get { return this.iva; }
            set { this.iva = value;
                this.OnPropertyChanged();
            }
        }

        [DisplayName("cta")]
        [JsonProperty("cta")]
        [XmlAttribute("cta")]
        public string CuentaContable {
            get { return this.cuentaContable; }
            set {
                this.cuentaContable = value;
                this.OnPropertyChanged();
            }
        }
    }
}
