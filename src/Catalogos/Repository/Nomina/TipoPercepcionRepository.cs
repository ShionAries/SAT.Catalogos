using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// catalogo de tipos de percepciones
    /// </summary>
    public class TipoPercepcionRepository : RepositoryContext<ClaveTipoPercepcion>, ITipoPercepcionRepository, IGeneralRepository {
        public TipoPercepcionRepository() {
            this.Title = "Catálogo de tipos de percepciones.";
            this.FileName = "CatalogoNominaTipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
