using System.Xml.Serialization;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de tipos de contrato
    /// </summary>
    [JsonObject("item")]
    [XmlRoot("item")]
    public class CveTipoContrato : ClaveBase, IClaveBase {
        public CveTipoContrato() {
        }
    }
}
