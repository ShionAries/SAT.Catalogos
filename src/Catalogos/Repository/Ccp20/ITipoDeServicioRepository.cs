using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de tipo servicio.
    /// </summary>
    public interface ITipoDeServicioRepository : IRepositoryContext<CveTipoDeServicio> {
        CveTipoDeServicio Search(string findId);
    }
}
