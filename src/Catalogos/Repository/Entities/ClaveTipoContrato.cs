// develop: 21010105
// purpose: Clave tipo de contrato Complemento Nomina 1.1 y 1.2
using System.Xml.Serialization;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Newtonsoft.Json;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo de tipos de contrato
    /// </summary>
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveTipoContrato : ClaveBase, IClaveBase {
        public ClaveTipoContrato() {
        }
    }
}
