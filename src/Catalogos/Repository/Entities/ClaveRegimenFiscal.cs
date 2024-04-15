using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo de Regimenes Fiscales
    /// </summary>
    [JsonObject("item")]
    public class ClaveRegimenFiscal : ClaveBaseVigencia, IClaveBaseItem {
        private string fisicaField;
        private string moralField;

        public ClaveRegimenFiscal() {
        }

        [JsonProperty("fisica")]
        [DataNames("Fisica")]
        public string FisicaX {
            get {
                return this.fisicaField;
            }
            set {
                this.fisicaField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool Fisica {
            get {
                return !this.fisicaField.ToLower().Contains("no");
            }
            set {
                if (!value) {
                    this.fisicaField = "No";
                } else {
                    this.fisicaField = "Si";
                }
            }
        }

        [JsonProperty("moral")]
        [DataNames("Moral")]
        public string MoralX {
            get {
                return this.moralField;
            }
            set {
                this.moralField = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool Moral {
            get {
                return !this.moralField.ToLower().Contains("no");
            }
            set {
                if (!value) {
                    this.moralField = "No";
                } else {
                    this.moralField = "Si";
                }
            }
        }
    }
}