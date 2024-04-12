using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Artículo 69-B, primer y segundo párrafo del CFF
    /// </summary>
    public class Articulo69Repository : RepositoryContext<NoLocalizados>, IArticulo69Repository, IGeneralRepository {
        public Articulo69Repository() {
            this.Title = "Artículo 69, primer y segundo párrafo del CFF";
            this.FileName = "Articulo69_NoLocalizados.json";
        }

        /// <summary>
        /// retorna un objeto codigo agrupador del catalogo del sat
        /// </summary>
        public NoLocalizados Search(string findId) {
            NoLocalizados objeto = new NoLocalizados();
            objeto = this.Items.Find((NoLocalizados p) => p.RFC == findId);
            return objeto;
        }
    }
}
