using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catalogo de productos y servicios.
    /// </summary>
    [JsonObject("item")]
    public class ClaveProdServ : ClaveBaseVigencia, IClaveBaseItem {
        #region declaraciones
        private string incluirIvaTrasladadoField;
        private string incluirIepsTrasladadoField;
        private string complementoField;
        private bool complementoFieldSpecified;
        private string palabrasSimilaresField;
        private bool palabrasSimilaresFieldSpecified;
        private int estimuloField;
        #endregion

        public ClaveProdServ() { }

        [JsonProperty("iva")]
        [DataNames("IncluirIvaTrasladado")]
        public string IncluirIvaTrasladado {
            get {
                return this.incluirIvaTrasladadoField;
            }
            set {
                this.incluirIvaTrasladadoField = value;
            }
        }

        [JsonProperty("ieps")]
        [DataNames("IncluirIepsTrasladado")]
        public string IncluirIepsTrasladado {
            get {
                return this.incluirIepsTrasladadoField;
            }
            set {
                this.incluirIepsTrasladadoField = value;
            }
        }

        /// <summary>
        /// obtener o establecer que complemento debe incluir
        /// </summary>
        [JsonProperty("comp")]
        [DataNames("Complemento")]
        public string Complemento {
            get {
                return this.complementoField;
            }
            set {
                this.complementoField = value;
                this.complementoFieldSpecified = true;
            }
        }

        [JsonProperty("est")]
        [DataNames("Estimulo")]
        public int Estimulo {
            get {
                return this.estimuloField;
            }
            set {
                this.estimuloField = value;
            }
        }

        [JsonProperty("sim")]
        [DataNames("PalabrasSimilares")]
        public string PalabrasSimilares {
            get {
                return this.palabrasSimilaresField;
            }
            set {
                this.palabrasSimilaresField = value;
                this.palabrasSimilaresFieldSpecified = true;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool ComplementoSpecified {
            get {
                return this.complementoFieldSpecified;
            }
            set {
                this.complementoFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool PalabrasSimilaresSpecified {
            get {
                return this.palabrasSimilaresFieldSpecified;
            }
            set {
                this.palabrasSimilaresFieldSpecified = value;
            }
        }
    }
}