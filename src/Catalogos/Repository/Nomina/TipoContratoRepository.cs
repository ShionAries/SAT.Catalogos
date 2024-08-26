using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// catalogo de tipos de contrato (nomina)
    /// </summary>
    public class TipoContratoRepository : RepositoryContext<CveTipoContrato>, ITipoContratoRepository, IGeneralRepository {
        public TipoContratoRepository() {
            this.Title = "Catálogo de tipos de contrato";
            this.FileName = "CatalogoNominaTipoContrato.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
