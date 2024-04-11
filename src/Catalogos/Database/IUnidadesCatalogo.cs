using Jaeger.SAT.Catalogos.Abstractions;
using Jaeger.SAT.Catalogos.Entities;

namespace Jaeger.SAT.Catalogos.Database {
    /// <summary>
    /// Catálogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    public interface IUnidadesCatalogo : ICatalogoGeneric<ClaveUnidad> {
        ClaveUnidad Search(string findId);

        System.Collections.Generic.IEnumerable<ClaveUnidad> GetSearch(string findId);
    }
}
