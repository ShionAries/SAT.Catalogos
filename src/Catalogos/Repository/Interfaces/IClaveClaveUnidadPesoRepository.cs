using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public interface IClaveClaveUnidadPesoRepository : IRepositoryContext<CveClaveUnidadPeso> {
        CveClaveUnidadPeso Seach(string findId);

        System.Collections.Generic.IEnumerable<CveClaveUnidadPeso> GetSearch(string findId);
    }
}
