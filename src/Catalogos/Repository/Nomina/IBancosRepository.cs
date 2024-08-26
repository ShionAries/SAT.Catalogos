using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    public interface IBancosRepository : IRepositoryContext<CveBanco> {
        CveBanco Search(string findId);
    }
}
