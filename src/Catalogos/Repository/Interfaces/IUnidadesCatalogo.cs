using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    public interface IUnidadesCatalogo : IGenericCatalogo<ClaveUnidad> {
        ClaveUnidad Search(string findId);

        System.Collections.Generic.IEnumerable<ClaveUnidad> GetSearch(string findId);
    }
}
