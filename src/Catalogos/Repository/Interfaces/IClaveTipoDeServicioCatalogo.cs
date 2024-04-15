using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de tipo servicio.
    /// </summary>
    public interface IClaveTipoDeServicioCatalogo : IGenericCatalogo<CveTipoDeServicio> {
        CveTipoDeServicio Search(string findId);
    }
}
