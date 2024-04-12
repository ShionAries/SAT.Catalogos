using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    public interface IUnidadesRepository : IRespositoryContext<ClaveUnidad> {
        ClaveUnidad Search(string findId);

        System.Collections.Generic.IEnumerable<ClaveUnidad> GetSearch(string findId);
    }
}
