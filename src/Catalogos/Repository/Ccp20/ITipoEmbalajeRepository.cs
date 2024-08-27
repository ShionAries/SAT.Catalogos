using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    public interface ITipoEmbalajeRepository : IRepositoryContext<CveTipoEmbalaje> {
        CveTipoEmbalaje Search(string findId);

        System.Collections.Generic.IEnumerable<CveTipoEmbalaje> GetSearch(string findId);
    }
}
