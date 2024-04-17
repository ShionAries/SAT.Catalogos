using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de tipos de relación entre CFDI.
    /// </summary>
    public interface ITipoRelacionCFDIRepository : IRepositoryContext<CveTipoRelacionCFDI> {
        CveTipoRelacionCFDI Search(string findId);
    }
}
