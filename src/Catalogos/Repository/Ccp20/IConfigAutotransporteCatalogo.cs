using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public interface IConfigAutotransporteCatalogo : IRepositoryContext<CveConfigAutotransporte> {
        CveConfigAutotransporte Search(string findId);
    }
}
