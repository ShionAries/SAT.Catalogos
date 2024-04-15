// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public class CveTipoPermiso : ClaveBaseVigencia, IClaveBaseItem {
       public string ClaveTransporte { get; set; }
    }
}
