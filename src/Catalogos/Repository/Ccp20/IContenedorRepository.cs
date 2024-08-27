using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de tipo de contenedor.
    /// </summary>
    public interface IContenedorRepository : IRepositoryContext<CveContenedor> {
        CveContenedor Search(string findId);
    }
}
