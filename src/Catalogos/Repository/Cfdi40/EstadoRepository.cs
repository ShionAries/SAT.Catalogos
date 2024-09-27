using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de estados
    /// </summary>
    public class EstadoRepository : RepositoryContext<CveEstado>, IEstadoRepository, IGeneralRepository {
        public EstadoRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de Estados";
            FileName = "EstadosCFDi40.json";
            this.AddLastUpdate(lastUpdate);
        }
    }
}
