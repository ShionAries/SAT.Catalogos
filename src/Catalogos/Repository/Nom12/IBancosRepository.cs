using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    public interface IBancosRepository : IRepositoryContext<CveBanco> {
        CveBanco Search(string findId);
    }
}
