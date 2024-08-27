using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo de tipos de jornada laboral.
    /// </summary>
    public class TipoJornadaRepository : RepositoryContext<CveTipoJornada>, ITipoJornadaRepository, IGeneralRepository {
        public TipoJornadaRepository() {
            this.Title = "Catálogo de tipos de jornada laboral.";
            this.FileName = "CatNom12TipoJornada.json";
            this.Version = "1.0";
            this.Revision = "A";
        }
    }
}
