using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de materiales peligrosos.
    /// </summary>
    public interface IMaterialPeligrosoRepository : IRepositoryContext<CveMaterialPeligroso> {
        System.Collections.Generic.IEnumerable<CveMaterialPeligroso> GetSearch(string findId);
    }
}
