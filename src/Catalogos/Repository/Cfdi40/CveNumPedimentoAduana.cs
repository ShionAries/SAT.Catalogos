using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI: Catálogo de números de pedimento operados por aduana y ejercicio.
    /// </summary>
    [JsonObject("item")]
    public class CveNumPedimentoAduana : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        private string _clave;
        public CveNumPedimentoAduana() { }

        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public string Clave {
            get {
                var numero = int.Parse(_clave);
                return numero.ToString("00");
            }
            set {
                this._clave = int.Parse(value).ToString("00");
            }
        }

        [JsonProperty("pat")]
        [DataNames("Patente")]
        public string Patente { get; set; }

        [JsonProperty("eje")]
        [DataNames("Ejercicio")]
        public int Ejercicio { get; set; }

        [JsonProperty("can")]
        [DataNames("Cantidad")]
        public int Cantidad { get; set; }
    }
}