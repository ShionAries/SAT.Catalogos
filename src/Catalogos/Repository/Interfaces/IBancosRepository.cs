using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IBancosRepository : IRepositoryContext<ClaveBanco> {
        ClaveBanco Search(string findId);
    }
}
