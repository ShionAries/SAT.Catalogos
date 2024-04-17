using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public interface IMetodoPagoRepository : IRepositoryContext<CveMetodoPago> {
        CveMetodoPago Search(string findId);
    }
}
