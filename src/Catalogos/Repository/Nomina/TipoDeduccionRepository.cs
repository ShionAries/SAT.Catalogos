using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Nomina Catalogo de tipos de deducciones
    /// </summary>
    public class TipoDeduccionRepository : RepositoryContext<ClaveTipoDeduccion>, ITipoDeduccionRepository, IGeneralRepository {
        public TipoDeduccionRepository() {
            Title = "Catálogo de tipos de deducciones.";
            FileName = "CatalogoTipoDeduccion.json";
            Version = "3.0";
            Revision = "0";
        }
    }
}
