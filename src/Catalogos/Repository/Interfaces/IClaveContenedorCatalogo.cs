using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de tipo de contenedor.
    /// </summary>
    public interface IClaveContenedorCatalogo : IGenericCatalogo<CveContenedor> {
        CveContenedor Search(string findId);
    }
}
