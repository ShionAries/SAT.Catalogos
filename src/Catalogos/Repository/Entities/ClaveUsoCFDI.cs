using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catalogo de uso de comprobantes
    /// </summary>
    [JsonObject("item")]
    public class ClaveUsoCFDI : ClaveBaseVigencia, IClaveBaseItem {
        private string fisicaField;
        private string moralField;
        private string regimenFiscalReceptorField;

        public ClaveUsoCFDI() : base() {
        }

        [DisplayName("Fisica")]
        [JsonProperty("fisica")]
        [DataNames("Fisica")]
        public string Fisica {
            get {
                return this.fisicaField;
            }
            set {
                this.fisicaField = value;
            }
        }

        [DisplayName("Moral")]
        [JsonProperty("moral")]
        [DataNames("Moral")]
        public string Moral {
            get {
                return this.moralField;
            }
            set {
                this.moralField = value;
            }
        }

        [DisplayName("Regimen Fiscal Receptor")]
        [JsonProperty("regimenFiscal")]
        [DataNames("RegimenFiscalReceptor")]
        public string RegimenFiscalReceptor {
            get { return this.regimenFiscalReceptorField; }
            set {
                this.regimenFiscalReceptorField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FisicaX {
            get {
                return this.fisicaField.ToLower().Contains("s");
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool MotalX {
            get {
                return this.moralField.ToLower().Contains("n");
            }
        }
    }
}
