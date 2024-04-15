using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// catalogo de periodicidad de retenciones
    /// </summary>
    public class ClaveRetencionPeriodicidad : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveRetencionPeriodicidad() { }

        /// <summary>
        /// obtener o establecer complemento que usa
        /// </summary>
        [DataNames("Complemento")]
        public string Complemento { get; set; }
    }
}
