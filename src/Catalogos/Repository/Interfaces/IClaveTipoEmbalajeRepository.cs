using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Contracts {
    public interface IClaveTipoEmbalajeRepository : IRepositoryContext<CveTipoEmbalaje> {
        CveTipoEmbalaje Search(string findId);

        System.Collections.Generic.IEnumerable<CveTipoEmbalaje> GetSearch(string findId);
    }
}
