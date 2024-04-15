using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public interface IClaveClaveUnidadPesoCatalogo : IGenericCatalogo<CveClaveUnidadPeso> {
        CveClaveUnidadPeso Seach(string findId);

        System.Collections.Generic.IEnumerable<CveClaveUnidadPeso> GetSearch(string findId);
    }
}
