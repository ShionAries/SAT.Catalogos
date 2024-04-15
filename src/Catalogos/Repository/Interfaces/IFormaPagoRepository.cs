using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IFormaPagoRepository : IRepositoryContext<ClaveFormaPago> {
        ClaveFormaPago Search(string findId);
    }
}
