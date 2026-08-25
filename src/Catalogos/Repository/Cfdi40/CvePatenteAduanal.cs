using Newtonsoft.Json;
using System.ComponentModel;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Patentes Aduanales
    /// </summary>
    [JsonObject("item")]
    public class CvePatenteAduanal : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        private string _clave;

        public CvePatenteAduanal() { }

        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public string Clave {
            get {
                var numero = int.Parse(_clave);
                return numero.ToString("0000");
            }
            set {
                this._clave = int.Parse(value).ToString("0000");
            }
        }
    }
}