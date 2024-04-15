using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo de tipos de nomina
    /// </summary>
    public class TipoNominaRepository : RepositoryContext<ClaveTipoNomina>, ITipoNominaRepository, IGeneralRepository {
        public TipoNominaRepository() {
            Title = "Catálogo de tipos de nómina.";
            FileName = "CatalogoNominaTipos.json";
        }
    }
}
