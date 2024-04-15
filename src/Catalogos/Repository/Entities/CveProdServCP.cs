// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de productos y servicios carta porte.
    /// </summary>
    public class CveProdServCP : ClaveBaseVigencia, IClaveBaseItem {
        public string PalabrasSimilares { get; set; }
        public string MaterialPeligroso { get; set; }
    }
}
