/// develop: 220120181502
/// purpose: clave de tipo de regimen nomina 1.2
using System.ComponentModel;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de tipos de regimen de contratacion
    /// </summary>
    [JsonObject("item")]
    public class CveTipoRegimen : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBaseItem {
        public CveTipoRegimen() : base() {        }

        /// <summary>
        /// el formato de la clave es de 2 digitos, por lo que se debe formatear a 2 digitos
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
