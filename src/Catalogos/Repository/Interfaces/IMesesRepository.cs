using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IMesesRepository : IRepositoryContext<ClaveMeses> {
        ClaveMeses Search(string findId);
    }
}
