using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IPaisesRepository : IRepositoryContext<ClavePais> {
        ClavePais Search(string findId);
    }
}
