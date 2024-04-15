using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Entities {
    [JsonObject("item")]
    public class Impuesto : BasePropertyChangeImplementation {
        private string claveField;
        private string nombreField;
        private string tipoField;
        private bool retencionField;
        private bool trasladoField;

        [DisplayName("Clave")]
        [JsonProperty("clv")]
        [XmlAttribute("clave")]
        public string Clave {
            get {
                return this.claveField;
            }
            set {
                this.claveField = value;
                this.OnPropertyChanged();
            }
        }

        [DisplayName("Descripción")]
        [JsonProperty("nom")]
        [XmlAttribute("nombre")]
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.OnPropertyChanged();
            }
        }

        [Description("Retención")]
        [DisplayName("Retención")]
        [JsonProperty("ret")]
        [XmlAttribute("retencion")]
        public bool Retencion {
            get {
                return this.retencionField;
            }
            set {
                this.retencionField = value;
                this.OnPropertyChanged();
            }
        }

        [Description("Impuesto Local o Federal")]
        [DisplayName("Tipo")]
        [JsonProperty("tip")]
        [XmlAttribute("tipo")]
        public string Tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
                this.OnPropertyChanged();
            }
        }

        [DisplayName("Traslado")]
        [JsonProperty("tra")]
        [XmlAttribute("traslado")]
        public bool Traslado {
            get {
                return this.trasladoField;
            }
            set {
                this.trasladoField = value;
                this.OnPropertyChanged();
            }
        }

        public Impuesto() {
            this.claveField = string.Empty;
            this.nombreField = string.Empty;
            this.tipoField = string.Empty;
            this.retencionField = false;
            this.trasladoField = false;
        }
    }
}