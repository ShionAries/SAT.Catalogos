using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public interface IMonedaRepository : IRepositoryContext<CveMoneda> {
        CveMoneda Search(string findId);
    }
}
