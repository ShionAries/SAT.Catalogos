using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Articulo69 {
    /// <summary>
    /// Artículo 69, primer y segundo párrafo del CFF
    /// </summary>
    public class Articulo69Repository : RepositoryContext<NoLocalizados>, IArticulo69Repository, IRepositoryGeneric {
        public Articulo69Repository() {
            Title = "Artículo 69, primer y segundo párrafo del CFF";
            FileName = "Articulo69_NoLocalizados.json";
        }

        public Articulo69Repository(System.DateTime? lastUpdate = null) {
            Title = "Artículo 69, primer y segundo párrafo del CFF";
            FileName = "Articulo69_NoLocalizados.json";
            this.AddLastUpdate(lastUpdate);
        }

        /// <summary>
        /// retorna un objeto codigo agrupador del catalogo del sat
        /// </summary>
        public override NoLocalizados Search(string findId) {
            NoLocalizados objeto = new NoLocalizados();
            objeto = Items.Find((p) => p.RFC == findId);
            return objeto;
        }
    }
}
