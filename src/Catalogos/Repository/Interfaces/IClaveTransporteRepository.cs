using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de la clave del transporte.
    /// </summary>
    public interface IClaveTransporteRepository : IRepositoryContext<CveTransporte> {
        CveTransporte Search(string findId);
    }
}
