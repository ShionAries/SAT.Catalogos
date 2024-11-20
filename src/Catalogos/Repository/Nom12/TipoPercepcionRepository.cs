using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de percepciones
    /// </summary>
    public class TipoPercepcionRepository : RepositoryContext<CveTipoPercepcion>, ITipoPercepcionRepository, IRepositoryGeneric {
        public TipoPercepcionRepository(System.DateTime? lastUpdate = null) {
            this.Description = "Catálogo de tipos de percepciones.";
            this.FileName = "CatNom12TipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
            this.AddLastUpdate(lastUpdate);
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
