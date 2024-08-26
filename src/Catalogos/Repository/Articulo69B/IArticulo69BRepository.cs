using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Articulo69B {
    /// <summary>
    /// Artículo 69-B, primer y segundo párrafo del CFF
    /// </summary>
    public interface IArticulo69BRepository : IRepositoryContext<Articulo69B>, IGeneralRepository {
        Articulo69B Search(string findId);
    }
}
