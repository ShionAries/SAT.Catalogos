using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de régimen fiscal.
    /// </summary>
    public interface IRegimenesFiscalesRepository : IRepositoryContext<ClaveRegimenFiscal> {
        ClaveRegimenFiscal Search(string findId);
    }
}
