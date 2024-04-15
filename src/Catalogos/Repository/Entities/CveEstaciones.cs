// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public class CveEstaciones : ClaveBaseVigencia, IClaveBaseItem {
        public string ClaveTransporte { get; set; }

        public string Nacionalidad { get; set; }

        public string DesignadorIATA { get; set; }

        public string LineaFerrea { get; set; }
    }
}
