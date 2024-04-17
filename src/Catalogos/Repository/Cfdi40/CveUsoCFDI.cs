using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de uso de comprobantes
    /// </summary>
    [JsonObject("item")]
    public class CveUsoCFDI : ClaveBaseVigencia, IClaveBaseItem {
        private string fisicaField;
        private string moralField;
        private string regimenFiscalReceptorField;

        public CveUsoCFDI() : base() { }

        [DisplayName("Fisica")]
        [JsonProperty("fisica")]
        [DataNames("Fisica")]
        public string Fisica {
            get {
                return fisicaField;
            }
            set {
                fisicaField = value;
            }
        }

        [DisplayName("Moral")]
        [JsonProperty("moral")]
        [DataNames("Moral")]
        public string Moral {
            get {
                return moralField;
            }
            set {
                moralField = value;
            }
        }

        [DisplayName("Regimen Fiscal Receptor")]
        [JsonProperty("regimenFiscal")]
        [DataNames("RegimenFiscalReceptor")]
        public string RegimenFiscalReceptor {
            get { return regimenFiscalReceptorField; }
            set {
                regimenFiscalReceptorField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FisicaX {
            get {
                return fisicaField.ToLower().Contains("s");
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool MotalX {
            get {
                return moralField.ToLower().Contains("n");
            }
        }
    }
}
