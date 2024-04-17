using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de periodicidad de retenciones
    /// </summary>
    public class CveRetencionPeriodicidad : ClaveBaseVigencia, IClaveBaseItem {
        public CveRetencionPeriodicidad() { }

        /// <summary>
        /// obtener o establecer complemento que usa
        /// </summary>
        [DataNames("Complemento")]
        public string Complemento { get; set; }
    }
}
