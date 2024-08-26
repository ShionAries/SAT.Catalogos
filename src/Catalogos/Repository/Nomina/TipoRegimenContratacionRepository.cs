using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// catalogo de tipos de regimen de contratacion
    /// </summary>
    public class TipoRegimenContratacionRepository : RepositoryContext<CveTipoRegimen>, ITipoRegimenContratacionRepository, IGeneralRepository {
        public TipoRegimenContratacionRepository() {
            this.Title = "Catálogo de tipos de régimen de contratación.";
            this.FileName = "CatalogoNominaTipoRegimenContratacion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
