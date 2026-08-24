using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0
    /// : Catalogo de productos y servicios.
    /// </summary>
    [JsonObject("item")]
    public class CveProdServ : ClaveBaseVigencia, IClaveBaseItem {
        #region declaraciones
        private string incluirIvaTrasladadoField;
        private string incluirIepsTrasladadoField;
        private string complementoField;
        private bool complementoFieldSpecified;
        private string palabrasSimilaresField;
        private bool palabrasSimilaresFieldSpecified;
        private int estimuloField;
        #endregion

        public CveProdServ() { this.PalabrasSimilares = string.Empty; }

        [JsonProperty("iva")]
        [DataNames("IncluirIvaTrasladado")]
        public string IncluirIvaTrasladado {
            get {
                return incluirIvaTrasladadoField;
            }
            set {
                incluirIvaTrasladadoField = value;
            }
        }

        [JsonProperty("ieps")]
        [DataNames("IncluirIepsTrasladado")]
        public string IncluirIepsTrasladado {
            get {
                return incluirIepsTrasladadoField;
            }
            set {
                incluirIepsTrasladadoField = value;
            }
        }

        /// <summary>
        /// obtener o establecer que complemento debe incluir
        /// </summary>
        [JsonProperty("comp")]
        [DataNames("Complemento")]
        public string Complemento {
            get {
                return complementoField;
            }
            set {
                complementoField = value;
                complementoFieldSpecified = true;
            }
        }

        [JsonProperty("est")]
        [DataNames("Estimulo")]
        public int Estimulo {
            get {
                return estimuloField;
            }
            set {
                estimuloField = value;
            }
        }

        [JsonProperty("sim")]
        [DataNames("PalabrasSimilares")]
        public string PalabrasSimilares {
            get {
                return palabrasSimilaresField;
            }
            set {
                palabrasSimilaresField = value;
                palabrasSimilaresFieldSpecified = true;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool ComplementoSpecified {
            get {
                return complementoFieldSpecified;
            }
            set {
                complementoFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool PalabrasSimilaresSpecified {
            get {
                return palabrasSimilaresFieldSpecified;
            }
            set {
                palabrasSimilaresFieldSpecified = value;
            }
        }
    }
}