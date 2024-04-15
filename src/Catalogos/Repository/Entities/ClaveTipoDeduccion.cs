using Newtonsoft.Json;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities
{
    /// <summary>
    /// Nomina: Catalogo de tipos de deducciones
    /// </summary>
    [JsonObject("item")]
    public class ClaveTipoDeduccion : ClaveBaseVigencia, IClaveBaseItem
    {
    }
}
