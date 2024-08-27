using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de la clave del transporte.
    /// </summary>
    public interface ITransporteRepository : IRepositoryContext<CveTransporte> {
        CveTransporte Search(string findId);
    }
}
