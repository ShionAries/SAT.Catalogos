using Jaeger.Catalogos.Contracts;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Repositories {
    public class TipoRegimenRepository : RepositoryContext<ClaveTipoRegimen>, ITipoRegimenRepository, IGeneralRepository {
        public TipoRegimenRepository() {
            this.Title = "Catálogo de tipos de percepciones.";
            this.FileName = "CatalogoTipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
