using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de percepciones
    /// </summary>
    public class TipoPercepcionRepository : RepositoryContext<CveTipoPercepcion>, ITipoPercepcionRepository, IGeneralRepository {
        public TipoPercepcionRepository() {
            this.Title = "Catálogo de tipos de percepciones.";
            this.FileName = "CatNom12TipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
