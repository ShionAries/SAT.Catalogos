using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo de patentes aduanales
    /// </summary>
    public class PatenteAduanalRepository : RepositoryContext<ClavePatenteAduanal>, IPatenteAduanalRepository, IGeneralRepository {
        public PatenteAduanalRepository() {
            Title = "Catálogo de patentes aduanales";
            FileName = "CatalogoPatentesAduanales.json";
            Revision = "0";
            Version = "25.0";
        }
    }
}
