using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Retenciones
    /// </summary>
    public class ClaveRetencionRepository : RepositoryContext<CveRetencion>, IClaveRetencionRepository, IGeneralRepository {
        public ClaveRetencionRepository() {
            Title = "Catálogo de Retenciones";
            FileName = "CarRet20CveRetenciones.json";
            Version = "1";
            Revision = "0";
        }
    }
}
