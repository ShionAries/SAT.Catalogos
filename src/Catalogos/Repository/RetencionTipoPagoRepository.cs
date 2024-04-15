using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Retenciones Catalogo tipo de pago de la retencion
    /// </summary>
    public class RetencionTipoPagoRepository : RepositoryContext<ClaveTipoDividendoUtilidadDistrib>, IRetencionTipoPagoRepository, IGeneralRepository {
        public RetencionTipoPagoRepository() {
        }
    }
}
