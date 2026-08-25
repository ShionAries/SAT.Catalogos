using System.ComponentModel;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Exportacion
    /// </summary>
    [JsonObject("item")]
    public class CveExportacion : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBaseItem {
        public CveExportacion() : base() { }

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