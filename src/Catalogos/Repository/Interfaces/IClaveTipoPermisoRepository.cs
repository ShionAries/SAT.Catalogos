using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Contracts {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public interface IClaveTipoPermisoRepository : IRepositoryContext<CveTipoPermiso>, IGeneralRepository {
        CveTipoPermiso Search(string findId);
    }
}
