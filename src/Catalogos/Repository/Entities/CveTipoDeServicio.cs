// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de tipo servicio.
    /// </summary>
    public class CveTipoDeServicio : ClaveBaseVigencia, IClaveBaseItem {
        public int Contenedor { get; set; }
    }
}
