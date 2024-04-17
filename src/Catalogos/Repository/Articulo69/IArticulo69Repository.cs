using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IArticulo69Repository : IRepositoryContext<NoLocalizados>, IGeneralRepository {
        NoLocalizados Search(string findId);
    }
}
