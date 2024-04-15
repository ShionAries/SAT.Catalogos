// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public class CveClaveUnidadPeso : ClaveBaseVigencia, IClaveBaseItem {
        public string Nombre { get; set; }
        public string Nota { get; set; }
        public string Simbolo { get; set; }
        public string Bandera { get; set; }
    }
}
