// develop: 210120180127
// purpose: Clave de pais, catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    public class CveTipoEstacion : ClaveBaseVigencia, IClaveBaseItem {
        public string ClaveTranspote { get; set; }
    }
}
