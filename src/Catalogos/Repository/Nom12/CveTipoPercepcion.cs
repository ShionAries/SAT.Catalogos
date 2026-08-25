using System.ComponentModel;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de tipos de percepciones
    /// </summary>
    [JsonObject("item")]
    public class CveTipoPercepcion : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBaseItem {

        public CveTipoPercepcion() : base() { }

        /// <summary>
        /// el formato de la clave es de 3 digitos, por lo que se debe formatear a 3 digitos
        /// </summary>
        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [Helpers.Mapping.DataNames("Clave")]
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
