// develop: 070720171730
// purpose: Catálogo de unidades de medida para los conceptos en el CFDI. Catalogo SAT

using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Abstractions;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Entities {
    /// <summary>
    /// CFDI: Catálogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveUnidad : ClaveBaseVigencia {
        private string nombreField;
        private string notasField;
        private string simboloField;
        private bool simboloFieldSpecified;

        public ClaveUnidad() {
        }

        [DisplayName("Nombre")]
        [JsonProperty("nom")]
        [XmlAttribute("nombre")]
        [DataNames("Nombre")]
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }

        [DisplayName("Notas")]
        [JsonProperty("nota")]
        [XmlAttribute("notas")]
        [DataNames("Notas")]
        public string Notas {
            get {
                return this.notasField;
            }
            set {
                this.notasField = value;
            }
        }

        [DisplayName("Símbolo")]
        [JsonProperty("sim")]
        [XmlAttribute("sim")]
        [DataNames("Sim")]
        public string Simbolo {
            get {
                return this.simboloField;
            }
            set {
                this.simboloField = value;
                this.simboloFieldSpecified = true;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        [XmlIgnore]
        public bool SimboloSpecified {
            get {
                return this.simboloFieldSpecified;
            }
            set {
                this.simboloFieldSpecified = value;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public override string Descriptor {
            get { return string.Format("{0}: {1}", this.Clave, this.Nombre); }
        }
    }
}