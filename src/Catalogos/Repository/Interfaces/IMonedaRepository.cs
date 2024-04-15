using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IMonedaRepository : IRepositoryContext<ClaveMoneda> {
        ClaveMoneda Search(string findId);
    }
}
