using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Articulo69B {
    /// <summary>
    /// Artículo 69-B, primer y segundo párrafo del CFF
    /// </summary>
    public class Articulo69BRepository : RepositoryContext<Articulo69B>, IArticulo69BRepository, IGeneralRepository {
        public Articulo69BRepository() {
            Title = "Artículo 69-B, primer y segundo párrafo del CFF";
            FileName = "Articulo69B_Completo.json";
        }

        public Articulo69BRepository(System.DateTime? lastUpdate = null) {
            Title = "Artículo 69-B, primer y segundo párrafo del CFF";
            FileName = "Articulo69B_Completo.json";
            if (lastUpdate != null ) { this.Actualizacion = lastUpdate; }
        }

        /// <summary>
        /// retorna un objeto codigo agrupador del catalogo del sat
        /// </summary>
        public Articulo69B Search(string findId) {
            Articulo69B objeto = new Articulo69B();
            objeto = Items.Find((p) => p.RFC == findId);
            return objeto;
        }
    }
}
