using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo del tipo de origen recurso.
    /// </summary>
    public class OrigenRecursoRepository : RepositoryContext<ClaveOrigenRecurso>, IOrigenRecursoRepository, IGeneralRepository {
        public OrigenRecursoRepository() {
            this.Title = "Catálogo del tipo de origen recurso.";
            this.FileName = "CatalogoNominaOrigenRecurso.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
