using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de Países
    /// </summary>
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveRetencionPais : ClaveBase, IClaveBase {
    }
}
