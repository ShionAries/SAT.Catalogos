using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de entidades federativas (retenciones)
    /// </summary>
    public interface IRetencionEntidadesFederativasRepository : IRepositoryContext<CveRetencionEntidadFederativa> {

        CveRetencionEntidadFederativa Search(string findId);
    }
}
