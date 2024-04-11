using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository {
    public interface IArticulo69BRepository : ICatalogoGeneric<Articulo69B>, IGeneralRepository {
        Articulo69B Search(string findId);
    }
}
