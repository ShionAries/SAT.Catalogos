using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo tipo de pago de la retencion
    /// </summary>
    public class RetencionTipoPagoRepository : RepositoryContext<CveTipoDividendoUtilidadDistrib>, IRetencionTipoPagoRepository, IGeneralRepository {
        public RetencionTipoPagoRepository() {
        }
    }
}
