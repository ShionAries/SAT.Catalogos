using Jaeger.SAT.Catalogos.Repository.Nomina;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IBancosRepository : IRepositoryContext<ClaveBanco> {
        ClaveBanco Search(string findId);
    }
}
