using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Impuestos
    /// </summary>
    [JsonObject("item")]
    public class CveImpuesto : ClaveBase, IClaveBase {
        private string retencionField;
        private string trasladoField;
        private string localFederalField;
        private string entidadField;

        public CveImpuesto() { }

        [JsonProperty("ret")]
        [DataNames("Retencion")]
        public string Retencion {
            get {
                return retencionField;
            }
            set {
                retencionField = value;
            }
        }

        [DisplayName("Traslado")]
        [JsonProperty("tra")]
        [DataNames("Traslado")]
        public string Traslado {
            get {
                return trasladoField;
            }
            set {
                trasladoField = value;
            }
        }

        [DisplayName("Local ó Federal")]
        [JsonProperty("loc")]
        [DataNames("LocalFederal")]
        public string LocalFederal {
            get {
                return localFederalField;
            }
            set {
                localFederalField = value;
            }
        }

        [DisplayName("Entidad en la que aplica")]
        [JsonProperty("ent")]
        [DataNames("Entidad")]
        public string Entidad {
            get {
                return entidadField;
            }
            set {
                entidadField = value;
            }
        }

        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public new string Clave {
            get {
                var numero = int.Parse(base.Clave);
                return numero.ToString("000");
            }
            set {
                base.Clave = int.Parse(value).ToString("000");
            }
        }
    }
}