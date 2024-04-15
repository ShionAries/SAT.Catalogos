using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catalogo de tipos de relacion entre CFDI
    /// </summary>
    [JsonObject("item")]
    [XmlRoot("item")]
    public class ClaveTipoRelacionCFDI : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveTipoRelacionCFDI() {

        }
    }
}