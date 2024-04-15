// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public class CveConfigAutotransporte : ClaveBaseVigencia, IClaveBaseItem {
        public string NumeroEjes { get; set; }
        public string NumeroLlantas { get; set; }
        public string Remolque { get; set; }
    }
}
