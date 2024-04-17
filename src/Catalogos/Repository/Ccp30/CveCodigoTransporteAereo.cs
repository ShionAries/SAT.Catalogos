
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo código transporte aéreo.
    /// </summary>
    public class CveCodigoTransporteAereo : ClaveBaseVigencia, IClaveBaseItem {
        /// <summary>
        /// obtener o establecer Nacionalidad
        /// </summary>
        [DataNames("Nacionalidad")]
        public string Nacionalidad { get; set; }

        /// <summary>
        /// obtener o establecer Designador OACI
        /// </summary>
        [DataNames("Designador")]
        public string Designador { get; set; }
    }
}
