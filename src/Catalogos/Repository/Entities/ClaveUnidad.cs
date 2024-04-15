using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catálogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    [JsonObject("item")]
    public class ClaveUnidad : ClaveBaseVigencia {
        private string nombreField;
        private string notasField;
        private string simboloField;
        private bool simboloFieldSpecified;

        public ClaveUnidad() {        }

        [DisplayName("Nombre")]
        [JsonProperty("nom")]
        [DataNames("Nombre")]
        public string Nombre {
            get {
                return nombreField;
            }
            set {
                nombreField = value;
            }
        }

        [DisplayName("Notas")]
        [JsonProperty("nota")]
        [DataNames("Notas")]
        public string Notas {
            get {
                return notasField;
            }
            set {
                notasField = value;
            }
        }

        [DisplayName("Símbolo")]
        [JsonProperty("sim")]
        [DataNames("Simbolo")]
        public string Simbolo {
            get {
                return simboloField;
            }
            set {
                simboloField = value;
                simboloFieldSpecified = true;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool SimboloSpecified {
            get {
                return simboloFieldSpecified;
            }
            set {
                simboloFieldSpecified = value;
            }
        }

        [JsonIgnore]
        public override string Descriptor {
            get { return string.Format("{0}: {1}", Clave, Nombre); }
        }
    }
}