using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Carta Porte 3.0 Clave de Producto y Servicios
    /// </summary>
    public class CveProdServCP : ClaveBaseVigencia, IClaveBaseItem {
        private string palabrasSimilaresField;
        private bool palabrasSimilaresFieldSpecified;

        public CveProdServCP() { }


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

        [DataNames("MaterialPeligroso")]
        public string MaterialPeligroso { get; set; }

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
