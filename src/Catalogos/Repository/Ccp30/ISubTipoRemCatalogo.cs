using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de tipo de remolque.
    /// </summary>
    public interface ISubTipoRemCatalogo : IRepositoryContext<CveSubTipoRemolque> {
        /// <summary>
        /// buscar descripcion
        /// </summary>
        IEnumerable<CveSubTipoRemolque> GetSearchBy(string descripcion);
    }
}
