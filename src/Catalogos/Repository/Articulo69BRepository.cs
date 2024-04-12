using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Artículo 69-B, primer y segundo párrafo del CFF
    /// </summary>
    public class Articulo69BRepository : RepositoryContext<Articulo69B>, IArticulo69BRepository, IGeneralRepository {
        public Articulo69BRepository() {
            this.Title = "Artículo 69-B, primer y segundo párrafo del CFF";
            this.FileName = "Articulo69B_Completo.json";
        }

        /// <summary>
        /// retorna un objeto codigo agrupador del catalogo del sat
        /// </summary>
        public Articulo69B Search(string findId) {
            Articulo69B objeto = new Articulo69B();
            objeto = this.Items.Find((Articulo69B p) => p.RFC == findId);
            return objeto;
        }
    }
}
