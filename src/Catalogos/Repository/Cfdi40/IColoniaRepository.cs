using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de colonias.
    /// </summary>
    public interface IColoniaRepository : IRepositoryContext<CveColonia> {
        CveColonia Search(string findId);
    }
}
