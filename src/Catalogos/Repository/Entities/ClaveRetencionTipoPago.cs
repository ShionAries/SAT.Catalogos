using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Retenciones Catalogo tipo de pago de la retencion
    /// </summary>
    public class ClaveRetencionTipoPago : ClaveBaseVigencia {
        [DataNames("TipoImpuesto")]
        public string TipoImpuesto { get; set; }
    }
}
