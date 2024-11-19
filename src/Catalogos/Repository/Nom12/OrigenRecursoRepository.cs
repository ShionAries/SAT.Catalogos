using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo del tipo de origen recurso.
    /// </summary>
    public class OrigenRecursoRepository : RepositoryContext<CveOrigenRecurso>, IOrigenRecursoRepository, IGeneralRepository {
        public OrigenRecursoRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo del tipo de origen recurso.";
            this.FileName = "CatNom12OrigenRecurso.json";
            this.Version = "1.0";
            this.Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveOrigenRecurso Search(string query) {
            throw new System.NotImplementedException();
        }
    }
}
