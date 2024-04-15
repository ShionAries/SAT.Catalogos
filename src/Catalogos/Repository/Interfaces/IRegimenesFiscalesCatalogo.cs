using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de régimen fiscal.
    /// </summary>
    public interface IRegimenesFiscalesCatalogo : IGenericCatalogo<ClaveRegimenFiscal> {
        ClaveRegimenFiscal Search(string findId);
    }
}
