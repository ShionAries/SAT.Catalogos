/// develop: anhe 17072019 1425
/// purpose: catalogo de tipos de cadena de pago aplicables para los complementos de comprobante de pagos.
using System.ComponentModel;
using System.Xml.Serialization;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Rep20 {
    /// <summary>
    /// Pagos: Catálogo del tipo de la cadena de pago.
    /// </summary>
    [XmlRoot("item")]
    [JsonObject("item")]
    public class CveTipoCadenaPago : ClaveBase, IClaveBase {
        public CveTipoCadenaPago() : base() { }

        /// <summary>
        /// El formato de la clave es de dos dígitos, por lo que se debe convertir a entero y luego formatear a dos dígitos.
        /// </summary>
        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
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
