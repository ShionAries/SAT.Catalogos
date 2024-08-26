using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// catalogo de tipos de nomina
    /// </summary>
    public class TipoNominaRepository : RepositoryContext<CveTipoNomina>, ITipoNominaRepository, IGeneralRepository {
        public TipoNominaRepository() {
            Title = "Catálogo de tipos de nómina.";
            FileName = "CatalogoNominaTipos.json";
        }
    }
}
