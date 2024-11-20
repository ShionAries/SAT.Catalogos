using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo de tipos de jornada laboral.
    /// </summary>
    public class TipoJornadaRepository : RepositoryContext<CveTipoJornada>, ITipoJornadaRepository, IRepositoryGeneric {
        public TipoJornadaRepository(System.DateTime? lastUpdate = null) {
            this.Description = "Catálogo de tipos de jornada laboral.";
            this.FileName = "CatNom12TipoJornada.json";
            this.Version = "1.0";
            this.Revision = "A";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoJornada Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveTipoJornada { Clave = query };
        }
    }
}
