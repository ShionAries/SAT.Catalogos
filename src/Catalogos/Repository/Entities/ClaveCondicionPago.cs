// develop: 210420171707
// purpose: Condiciones de pago
using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveCondicionPago : ClaveBase, IClaveBase {

    }
}
