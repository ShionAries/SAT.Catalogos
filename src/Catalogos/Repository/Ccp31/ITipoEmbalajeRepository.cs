using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    public interface ITipoEmbalajeRepository : IRepositoryContext<CveTipoEmbalaje> {
        System.Collections.Generic.IEnumerable<CveTipoEmbalaje> GetSearch(string findId);
    }
}
