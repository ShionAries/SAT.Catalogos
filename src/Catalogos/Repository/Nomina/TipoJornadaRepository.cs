using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Catalogo de tipos de jornada laboral.
    /// </summary>
    public class TipoJornadaRepository : RepositoryContext<ClaveTipoJornada>, ITipoJornadaRepository, IGeneralRepository {
        public TipoJornadaRepository() {
            this.Title = "Catálogo de tipos de jornada laboral.";
            this.FileName = "CatalogoNominaTipoJornada.json";
            this.Version = "1.0";
            this.Revision = "A";
        }
    }
}
