using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de Estacion
    /// </summary>
    public interface ICveTipoEstacionRepository : IRepositoryContext<CveTipoEstacion> {
        CveTipoEstacion Search(string findId);
    }
}
