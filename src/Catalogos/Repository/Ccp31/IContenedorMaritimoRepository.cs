using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de contenedores marítimos.
    /// </summary>
    public interface IContenedorMaritimoRepository : IRepositoryContext<CveContenedorMaritimo> {
        CveContenedorMaritimo Search(string findId);
    }
}
