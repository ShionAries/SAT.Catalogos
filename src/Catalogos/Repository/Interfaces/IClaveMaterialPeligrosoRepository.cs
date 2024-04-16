using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Contracts {
    /// <summary>
    /// Catálogo de materiales peligrosos.
    /// </summary>
    public interface IClaveMaterialPeligrosoRepository : IRepositoryContext<CveMaterialPeligroso> {
        CveMaterialPeligroso Search(string findId);

        System.Collections.Generic.IEnumerable<CveMaterialPeligroso> GetSearch(string findId);
    }
}
