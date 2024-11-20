using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    public interface IUnidadesRepository : IRepositoryContext<CveUnidad> {
        System.Collections.Generic.IEnumerable<CveUnidad> GetSearch(string findId);
    }
}
