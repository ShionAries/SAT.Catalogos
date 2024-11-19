using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public interface ITipoPermisoRepository : IRepositoryContext<CveTipoPermiso>, IRepositoryGeneric {
        CveTipoPermiso Search(string findId);
    }
}
