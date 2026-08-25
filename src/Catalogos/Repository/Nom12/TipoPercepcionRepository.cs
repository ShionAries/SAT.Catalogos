using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de percepciones
    /// </summary>
    public class TipoPercepcionRepository : RepositoryContext<CveTipoPercepcion>, ITipoPercepcionRepository, Interfaces.IRepositoryGeneric {
        public TipoPercepcionRepository() : base() {
            this.Description = "Catálogo de tipos de percepciones.";
            this.FileName = "CatNom12TipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }

        public override CveTipoPercepcion Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveTipoPercepcion { Clave = query };
        }
    }
}
