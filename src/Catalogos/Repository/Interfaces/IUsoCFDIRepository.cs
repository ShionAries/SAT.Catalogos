using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de uso de comprobantes.
    /// </summary>
    public interface IUsoCFDIRepository : IRepositoryContext<ClaveUsoCFDI> {
        ClaveUsoCFDI Search(string findId);
    }
}
