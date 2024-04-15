using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionTipoImpuestoRepository : RepositoryContext<ClaveRetencionTipoImpuesto>, IRetencionTipoImpuestoRepository, IGeneralRepository {
        public RetencionTipoImpuestoRepository() {
            
        }
    }
}
