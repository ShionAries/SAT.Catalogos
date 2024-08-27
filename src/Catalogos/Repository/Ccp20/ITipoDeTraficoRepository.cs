using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de tipo de tráfico ferroviario.
    /// </summary>
    public interface ITipoDeTraficoRepository : IRepositoryContext<CveTipoDeTrafico> {
        CveTipoDeTrafico Search(string findId);
    }
}
