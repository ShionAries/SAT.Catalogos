using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    [JsonObject("item")]
    public class ClaveImpuesto : ClaveBase, IClaveBase {
        private string retencionField;
        private string trasladoField;
        private string localFederalField;
        private string entidadField;

        public ClaveImpuesto() { }

        [JsonProperty("ret")]
        [DataNames("Retencion")]
        public string Retencion {
            get {
                return this.retencionField;
            }
            set {
                this.retencionField = value;
            }
        }

        [DisplayName("Traslado")]
        [JsonProperty("tra")]
        [DataNames("Traslado")]
        public string Traslado {
            get {
                return this.trasladoField;
            }
            set {
                this.trasladoField = value;
            }
        }

        [DisplayName("Local ó Federal")]
        [JsonProperty("loc")]
        [DataNames("LocalFederal")]
        public string LocalFederal {
            get {
                return this.localFederalField;
            }
            set {
                this.localFederalField = value;
            }
        }

        [DisplayName("Entidad en la que aplica")]
        [JsonProperty("ent")]
        [DataNames("Entidad")]
        public string Entidad {
            get {
                return this.entidadField;
            }
            set {
                this.entidadField = value;
            }
        }
    }
}