using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones Catalogo tipo de pago de la retencion
    /// </summary>
    public class CveRetencionTipoPago : ClaveBaseVigencia {
        [DataNames("TipoImpuesto")]
        public string TipoImpuesto { get; set; }
    }
}
