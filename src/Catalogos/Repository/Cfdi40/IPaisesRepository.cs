using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public interface IPaisesRepository : IRepositoryContext<CvePais> {
        CvePais Search(string findId);
    }
}
