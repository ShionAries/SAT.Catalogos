using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public interface IClaveConfigAutotransporteCatalogo : IGenericCatalogo<CveConfigAutotransporte> {
        CveConfigAutotransporte Search(string findId);
    }
}
