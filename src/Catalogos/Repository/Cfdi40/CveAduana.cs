using System.ComponentModel;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).
    /// </summary>
    [JsonObject("item")]
    public class CveAduana : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBaseItem {
        public CveAduana() : base() { }

        /// <summary>
        /// clave de dos dígitos que identifica a la aduana de entrada o salida de mercancías.
        /// </summary>
        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [Helpers.Mapping.DataNames("Clave")]
        public new string Clave {
            get {
                var numero = int.Parse(base.Clave);
                return numero.ToString("00");
            }
            set {
                base.Clave = int.Parse(value).ToString("00");
            }
        }
    }
}