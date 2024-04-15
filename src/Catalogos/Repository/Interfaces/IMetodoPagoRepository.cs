using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IMetodoPagoRepository : IRepositoryContext<ClaveMetodoPago> {
        ClaveMetodoPago Search(string findId);
    }
}
