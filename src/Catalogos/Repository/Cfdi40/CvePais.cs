using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de paises
    /// </summary>
    [JsonObject("item")]
    public class CvePais : ClaveBase, IClaveBase {
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
                return formatoCodigoField;
            }
            set {
                formatoCodigoField = value;
            }
        }

        [DisplayName("Formato de Registro de Identidad Tributaria")]
        [JsonProperty("frmr")]
        [DataNames("FormatoRegistroIden")]
        public string FormatoRegistroIden {
            get {
                return formatoRegistroIdenField;
            }
            set {
                formatoRegistroIdenField = value;
            }
        }

        [DisplayName("Validación del Registro de Identidad Tributaria")]
        [JsonProperty("valr")]
        [DataNames("ValidacionRegistroIden")]
        public string ValidacionRegistroIden {
            get {
                return validacionRegistroIdenField;
            }
            set {
                validacionRegistroIdenField = value;
            }
        }

        [Description("Agrupaciones")]
        [DisplayName("Agrupaciones")]
        [JsonProperty("agrp")]
        [DataNames("Agrupaciones")]
        public string Agrupaciones {
            get {
                return agrupacionesField;
            }
            set {
                agrupacionesField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FormatoCodigoSpecified {
            get {
                return formatoCodigoFieldSpecified;
            }
            set {
                formatoCodigoFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FormatoRegistroIdenSpecified {
            get {
                return formatoRegistroIdenFieldSpecified;
            }
            set {
                formatoRegistroIdenFieldSpecified = value;
            }
        }

        [JsonIgnore]
        public bool ValidacionRegistroIdenSpecified {
            get {
                return validacionRegistroIdenFieldSpecified;
            }
            set {
                validacionRegistroIdenFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool AgrupacionesSpecified {
            get {
                return agrupacionesFieldSpecified;
            }
            set {
                agrupacionesFieldSpecified = value;
            }
        }
    }
}