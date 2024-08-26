using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de uso de comprobantes
    /// </summary>
    public interface IUsoCFDIRepository : IRepositoryContext<CveUsoCFDI> {
        CveUsoCFDI Search(string findId);
    }
}
