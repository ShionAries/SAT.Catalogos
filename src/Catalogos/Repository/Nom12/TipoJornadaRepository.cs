using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo de tipos de jornada laboral.
    /// </summary>
    public class TipoJornadaRepository : RepositoryContext<CveTipoJornada>, ITipoJornadaRepository, Interfaces.IRepositoryGeneric {
        public TipoJornadaRepository() : base() {
            this.Description = "Catálogo de tipos de jornada laboral.";
            this.FileName = "CatNom12TipoJornada.json";
            this.Version = "1.0";
            this.Revision = "A";
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
