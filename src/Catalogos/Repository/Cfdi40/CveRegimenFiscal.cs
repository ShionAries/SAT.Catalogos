using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Regimenes Fiscales
    /// </summary>
    [JsonObject("item")]
    public class CveRegimenFiscal : ClaveBaseVigencia, IClaveBaseItem {
        private string fisicaField;
        private string moralField;

        public CveRegimenFiscal() {
        }

        [JsonProperty("fisica")]
        [DataNames("Fisica")]
        public string FisicaX {
            get {
                return fisicaField;
            }
            set {
                fisicaField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool Fisica {
            get {
                return !fisicaField.ToLower().Contains("no");
            }
            set {
                if (!value) {
                    fisicaField = "No";
                } else {
                    fisicaField = "Si";
                }
            }
        }

        [JsonProperty("moral")]
        [DataNames("Moral")]
        public string MoralX {
            get {
                return moralField;
            }
            set {
                moralField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool Moral {
            get {
                return !moralField.ToLower().Contains("no");
            }
            set {
                if (!value) {
                    moralField = "No";
                } else {
                    moralField = "Si";
                }
            }
        }
    }
}