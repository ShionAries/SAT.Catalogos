using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de Estacion
    /// </summary>
    public interface ITipoEstacionRepository : IRepositoryContext<CveTipoEstacion> {
        CveTipoEstacion Search(string findId);
    }
}
