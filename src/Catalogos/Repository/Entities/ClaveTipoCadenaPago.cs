// develop: 130820181337
// purpose: clave de tipo de pago, para el comprobante de pago
using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities
{
    /// <summary>
    /// Pagos: Catálogo del tipo de la cadena de pago.
    /// </summary>
    [XmlRoot("item")]
    [JsonObject("item")]
    public class ClaveTipoCadenaPago : ClaveBase, IClaveBase
    {
        public ClaveTipoCadenaPago()
        {

        }
    }
}
