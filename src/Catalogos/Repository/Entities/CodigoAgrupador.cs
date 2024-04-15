using System.ComponentModel;
using System.Xml.Serialization;
using Jaeger.Catalogos.Abstractions;
using Newtonsoft.Json;

namespace Jaeger.Catalogos.Entities {
    [JsonObject("item")]
    [XmlRoot("item")]
    public class CodigoAgrupador : BasePropertyChangeImplementation {
        private string strLevel;
        private string strCode;
        private string strName;

        /// <summary>
        /// constructor
        /// </summary>
        public CodigoAgrupador() {
            this.strLevel = string.Empty;
            this.strCode = string.Empty;
            this.strName = string.Empty;
        }

        /// <summary>
        /// constructor
        /// </summary>
        public CodigoAgrupador(string sLevel, string sCode, string sName) {
            this.strLevel = string.Empty;
            this.strCode = string.Empty;
            this.strName = string.Empty;
            this.strLevel = sLevel;
            this.strCode = sCode;
            this.strName = sName;
        }

        [DisplayName("Codigo")]
        [JsonProperty("codigo")]
        [XmlAttribute("codigo")]
        public string Clave {
            get {
                return this.strCode;
            }
            set {
                this.strCode = value;
                this.OnPropertyChanged();
            }
        }

        [DisplayName("Nivel")]
        [JsonProperty("nivel")]
        [XmlAttribute("nivel")]
        public string Nivel {
            get {
                return this.strLevel;
            }
            set {
                this.strLevel = value;
                this.OnPropertyChanged();
            }
        }

        [DisplayName("Descripción")]
        [JsonProperty("nom")]
        [XmlAttribute("nombre")]
        public string Nombre {
            get {
                return this.strName;
            }
            set {
                this.strName = value;
                this.OnPropertyChanged();
            }
        }
    }
}