using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo de retenciones
    /// </summary>
    public class RetencionesRepository : RepositoryContext<ClaveRetencion>, IRetencionesRepository, IGeneralRepository {
        public RetencionesRepository() {
            Title = "Catálogo de Retenciones";
            FileName = "CatalogoRetenciones.json";
        }
    }
}
