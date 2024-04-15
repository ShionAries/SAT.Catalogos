using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de colonias.
    /// </summary>
    public interface IClaveColoniaRepository : IRepositoryContext<ClaveColonia> {
        ClaveColonia Search(string findId);
    }
}
