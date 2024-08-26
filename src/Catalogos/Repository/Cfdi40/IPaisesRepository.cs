using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de paises
    /// </summary>
    public interface IPaisesRepository : IRepositoryContext<CvePais> {
        CvePais Search(string findId);
    }
}
