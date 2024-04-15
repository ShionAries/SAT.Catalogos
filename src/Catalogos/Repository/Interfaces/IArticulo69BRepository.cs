using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IArticulo69BRepository : IRepositoryContext<Articulo69B>, IGeneralRepository {
        Articulo69B Search(string findId);
    }
}
