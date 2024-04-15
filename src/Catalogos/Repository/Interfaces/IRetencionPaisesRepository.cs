using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IRetencionPaisesRepository : IRepositoryContext<ClaveRetencionPais> {

        ClaveRetencionPais Search(string findId);
    }
}
