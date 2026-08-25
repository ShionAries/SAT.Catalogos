using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo del tipo de origen recurso.
    /// </summary>
    public class OrigenRecursoRepository : RepositoryContext<CveOrigenRecurso>, IOrigenRecursoRepository, Interfaces.IRepositoryGeneric {
        public OrigenRecursoRepository() : base() {
            this.Description = "Catálogo del tipo de origen recurso.";
            this.FileName = "CatNom12OrigenRecurso.json";
            this.Version = "1.0";
            this.Revision = "0";
        }

        public override CveOrigenRecurso Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                return search;
            } catch (System.Exception) {
                System.Console.WriteLine($"Error: No se encontró el elemento con clave '{query}' en el catálogo de origen recurso.");
            }
            return new CveOrigenRecurso { Clave = query };
        }
    }
}
