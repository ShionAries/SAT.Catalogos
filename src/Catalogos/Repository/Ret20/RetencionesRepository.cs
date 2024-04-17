using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Retenciones
    /// </summary>
    public class RetencionesRepository : RepositoryContext<CveRetencion>, IRetencionesRepository, IGeneralRepository {
        public RetencionesRepository() {
            Title = "Catálogo de Retenciones";
            FileName = "RetencionesRet20.json";
            Version = "1";
            Revision = "0";
        }
    }
}
