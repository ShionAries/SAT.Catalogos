using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IFormaPagoRepository : IRespositoryContext<ClaveFormaPago> {
        ClaveFormaPago Search(string findId);
    }
}
