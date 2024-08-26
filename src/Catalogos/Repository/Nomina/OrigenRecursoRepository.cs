using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Catalogo del tipo de origen recurso.
    /// </summary>
    public class OrigenRecursoRepository : RepositoryContext<CveOrigenRecurso>, IOrigenRecursoRepository, IGeneralRepository {
        public OrigenRecursoRepository() {
            this.Title = "Catálogo del tipo de origen recurso.";
            this.FileName = "CatalogoNominaOrigenRecurso.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
