using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public interface IUnidadPesoRepository : IRepositoryContext<CveUnidadPeso> {
        CveUnidadPeso Search(string findId);

        System.Collections.Generic.IEnumerable<CveUnidadPeso> GetSearch(string findId);
    }
}
