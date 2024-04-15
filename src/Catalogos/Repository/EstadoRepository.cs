using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de estados
    /// </summary>
    public class EstadoRepository : RepositoryContext<ClaveEstado>, IEstadoRepository, IGeneralRepository {
        public EstadoRepository() {
            this.Title = "Catálogo de Estados";
            this.FileName = "CatalogoNominaEstados.json";
        }
    }
}
