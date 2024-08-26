using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de patentes aduanales
    /// </summary>
    public class PatenteAduanalRepository : RepositoryContext<CvePatenteAduanal>, IPatenteAduanalRepository, IGeneralRepository {
        public PatenteAduanalRepository() {
            Title = "Catálogo de patentes aduanales";
            FileName = "PatentesAduanalesCFDI40.json";
            Revision = "0";
            Version = "25.0";
        }
    }
}
