using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Bancos {
    public interface IBancosRepository : IRepositoryContext<ClaveBanco>, IRepositoryGeneric {
        new ClaveBanco Search(string findId);
    }
}
