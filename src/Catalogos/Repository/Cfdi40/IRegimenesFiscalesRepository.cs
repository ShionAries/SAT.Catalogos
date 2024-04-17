using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de régimen fiscal.
    /// </summary>
    public interface IRegimenesFiscalesRepository : IRepositoryContext<CveRegimenFiscal> {
        CveRegimenFiscal Search(string findId);
    }
}
