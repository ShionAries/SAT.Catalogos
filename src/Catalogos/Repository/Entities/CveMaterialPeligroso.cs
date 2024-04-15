// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de materiales peligrosos.
    /// </summary>
    public class CveMaterialPeligroso : ClaveBaseVigencia, IClaveBaseItem {
        public string Clase { get; set; }
        public string PeligroSecundario { get; set; }

        public string NombreTecnico { get; set; }

    }
}
