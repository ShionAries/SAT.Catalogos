// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo derechos de paso.
    /// </summary>
    public class CveDerechosDePaso : ClaveBaseVigencia, IClaveBaseItem {
        public string Entre { get; set; }
        public string Hasta { get; set; }
        public string OtorgaRecibe { get; set; }
    }
}
