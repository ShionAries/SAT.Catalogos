using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public interface IFormaPagoRepository : IRepositoryContext<CveFormaPago> {
        CveFormaPago Search(string findId);
    }
}
