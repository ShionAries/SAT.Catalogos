using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Carta Porte 3.0 Clave de Producto y Servicios
    /// </summary>
    public class ClaveProdServCP : ClaveBaseVigencia, IClaveBaseItem {
        private string palabrasSimilaresField;
        private bool palabrasSimilaresFieldSpecified;

        public ClaveProdServCP() { }


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

        [DataNames("MaterialPeligroso")]
        public string MaterialPeligroso { get; set; }

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
