using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo Tipo de Documento
    /// </summary>
    public class RetencionTipoImpuestoRepository : RepositoryContext<CveRetencionTipoImpuesto>, IRetencionTipoImpuestoRepository, IGeneralRepository {
        public RetencionTipoImpuestoRepository() {

        }
    }
}
