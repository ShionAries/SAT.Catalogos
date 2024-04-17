using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Repositories {
    /// <summary>
    /// catalogo de tipos de percepciones
    /// </summary>
    public class TipoPercepcionRepository : RepositoryContext<ClaveTipoPercepcion>, ITipoPercepcionRepository, IGeneralRepository {
        public TipoPercepcionRepository() {
            this.Title = "Catálogo de tipos de percepciones.";
            this.FileName = "CatalogoTipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
