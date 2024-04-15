using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de tipos de relación entre CFDI.
    /// </summary>
    public interface ITipoRelacionCFDIRepository : IRepositoryContext<ClaveTipoRelacionCFDI> {
        ClaveTipoRelacionCFDI Search(string findId);
    }
}
