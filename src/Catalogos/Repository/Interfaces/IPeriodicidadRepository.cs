using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IPeriodicidadRepository : IRepositoryContext<ClavePeriodicidad> {
        ClavePeriodicidad Search(string findId);
    }
}
