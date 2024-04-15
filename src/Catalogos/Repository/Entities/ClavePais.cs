using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo de paises
    /// </summary>
    [JsonObject("item")]
    public class ClavePais : ClaveBase, IClaveBase {
        private string formatoCodigoField;
        private bool formatoCodigoFieldSpecified;
        private string formatoRegistroIdenField;
        private bool formatoRegistroIdenFieldSpecified;
        private string validacionRegistroIdenField;
        private bool validacionRegistroIdenFieldSpecified;
        private string agrupacionesField;
        private bool agrupacionesFieldSpecified;

        [DisplayName("Formato de Código Postal")]
        [JsonProperty("frmc")]
        [DataNames("FormatoCodigoPostal")]
        public string FormatoCodigoPostal {
            get {
                return this.formatoCodigoField;
            }
            set {
                this.formatoCodigoField = value;
            }
        }

        [DisplayName("Formato de Registro de Identidad Tributaria")]
        [JsonProperty("frmr")]
        [DataNames("FormatoRegistroIden")]
        public string FormatoRegistroIden {
            get {
                return this.formatoRegistroIdenField;
            }
            set {
                this.formatoRegistroIdenField = value;
            }
        }

        [DisplayName("Validación del Registro de Identidad Tributaria")]
        [JsonProperty("valr")]
        [DataNames("ValidacionRegistroIden")]
        public string ValidacionRegistroIden {
            get {
                return this.validacionRegistroIdenField;
            }
            set {
                this.validacionRegistroIdenField = value;
            }
        }

        [Description("Agrupaciones")]
        [DisplayName("Agrupaciones")]
        [JsonProperty("agrp")]
        [DataNames("Agrupaciones")]
        public string Agrupaciones {
            get {
                return this.agrupacionesField;
            }
            set {
                this.agrupacionesField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FormatoCodigoSpecified {
            get {
                return this.formatoCodigoFieldSpecified;
            }
            set {
                this.formatoCodigoFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FormatoRegistroIdenSpecified {
            get {
                return this.formatoRegistroIdenFieldSpecified;
            }
            set {
                this.formatoRegistroIdenFieldSpecified = value;
            }
        }

        [JsonIgnore]
        public bool ValidacionRegistroIdenSpecified {
            get {
                return this.validacionRegistroIdenFieldSpecified;
            }
            set {
                this.validacionRegistroIdenFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool AgrupacionesSpecified {
            get {
                return this.agrupacionesFieldSpecified;
            }
            set {
                this.agrupacionesFieldSpecified = value;
            }
        }
    }
}