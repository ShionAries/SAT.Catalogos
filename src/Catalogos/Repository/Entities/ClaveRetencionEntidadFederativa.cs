/// develop: 310520181137 
/// purpose: clave de entidades federativas para el comprobante de retenciones
using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveRetencionEntidadFederativa : ClaveBase, IClaveBase {
    }
}
