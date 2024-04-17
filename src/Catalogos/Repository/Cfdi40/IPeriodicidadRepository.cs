using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IPeriodicidadRepository : IRepositoryContext<CvePeriodicidad> {
        CvePeriodicidad Search(string findId);
    }
}
