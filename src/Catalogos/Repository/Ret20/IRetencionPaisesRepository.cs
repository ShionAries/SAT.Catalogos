using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Pais
    /// </summary>
    public interface IRetencionPaisesRepository : IRepositoryContext<CveRetencionPais> {

        CveRetencionPais Search(string findId);
    }
}
