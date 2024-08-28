/// develop: anhe 17072019 1425
/// purpose: catalogo de tipos de cadena de pago aplicables para los complementos de comprobante de pagos.
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Jaeger.SAT.Catalogos.Repository.Rep20 {
    /// <summary>
    /// Pagos: Catálogo del tipo de la cadena de pago.
    /// </summary>
    [XmlRoot("item")]
    [JsonObject("item")]
    public class CveTipoCadenaPago : ClaveBase, IClaveBase {
        public CveTipoCadenaPago() : base() { }
    }
}
