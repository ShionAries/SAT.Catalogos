using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public interface IUnidadPesoRepository : IRepositoryContext<CveUnidadPeso> {
        System.Collections.Generic.IEnumerable<CveUnidadPeso> GetSearch(string findId);
    }
}
