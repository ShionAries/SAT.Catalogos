using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Articulo69B {
    /// <summary>
    /// Artículo 69-B, primer y segundo párrafo del CFF
    /// </summary>
    public class Articulo69BRepository : RepositoryContext<Articulo69B>, IArticulo69BRepository, IRepositoryGeneric {
        public Articulo69BRepository() {
            Description = "Artículo 69-B, primer y segundo párrafo del CFF";
            FileName = "Articulo69B_Completo.json";
        }

        public Articulo69BRepository(System.DateTime? lastUpdate = null) {
            Description = "Artículo 69-B, primer y segundo párrafo del CFF";
            FileName = "Articulo69B_Completo.json";
            this.AddLastUpdate(lastUpdate);
        }

        public override Articulo69B Search(string query) {
            Articulo69B objeto = new Articulo69B();
            objeto = Items.Find((p) => p.RFC == query);
            return objeto;
        }
    }
}
