using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public interface IMesesRepository : IRepositoryContext<CveMeses> {
        CveMeses Search(string findId);
    }
}
