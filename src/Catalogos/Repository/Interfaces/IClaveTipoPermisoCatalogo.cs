using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public interface IClaveTipoPermisoCatalogo : IGenericCatalogo<CveTipoPermiso> {
        CveTipoPermiso Search(string findId);
    }
}
