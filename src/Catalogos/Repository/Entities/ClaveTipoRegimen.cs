/// develop: 220120181502
/// purpose: clave de tipo de regimen nomina 1.2
using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Nomina: Catalogo de tipos de regimen de contratacion
    /// </summary>
    [JsonObject("item")]
    public class ClaveTipoRegimen : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveTipoRegimen() {
        }
    }
}
