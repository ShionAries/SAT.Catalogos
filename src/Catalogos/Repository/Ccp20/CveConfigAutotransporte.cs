using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public class CveConfigAutotransporte : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("NumeroEjes")]
        public string NumeroEjes { get; set; }

        [DataNames("NumeroLlantas")]
        public string NumeroLlantas { get; set; }

        [DataNames("Remolque")]
        public string Remolque { get; set; }
    }
}
