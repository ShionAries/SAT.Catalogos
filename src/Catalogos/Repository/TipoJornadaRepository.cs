using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Repositories {
    public class TipoJornadaRepository : RepositoryContext<ClaveTipoJornada>, ITipoJornadaCatalogo, IGeneralRepository {
        public TipoJornadaRepository() {
            this.Title = "Catálogo de tipos de jornada laboral.";
            this.FileName = "CatalogoNominaTipoJornada.json";
            this.Version = "1.0";
            this.Revision = "A";
        }
    }
}
