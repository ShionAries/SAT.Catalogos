using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IArticulo69Repository : IRespositoryContext<NoLocalizados>, IGeneralRepository {
        NoLocalizados Search(string findId);
    }
}
