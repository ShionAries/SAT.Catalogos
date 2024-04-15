using Jaeger.Catalogos.Entities;
using System.Collections.Generic;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de tipo de remolque.
    /// </summary>
    public interface IClaveSubTipoRemCatalogo : IGenericCatalogo<CveSubTipoRem> {
        CveSubTipoRem Search(string findId);

        /// <summary>
        /// buscar descripcion
        /// </summary>
        IEnumerable<CveSubTipoRem> GetSearchBy(string descripcion);
    }

    public interface ICveEstadoCatalogo : IGenericCatalogo<CveEstado> {
        CveEstado Search(string descripcion);
        IEnumerable<CveEstado> GetSearchBy(string descripcion);
    }
}
