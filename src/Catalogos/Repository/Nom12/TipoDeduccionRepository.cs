using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina Catalogo de tipos de deducciones
    /// </summary>
    public class TipoDeduccionRepository : RepositoryContext<CveTipoDeduccion>, ITipoDeduccionRepository, Interfaces.IRepositoryGeneric {
        public TipoDeduccionRepository() : base() {
            this.Description = "Catálogo de tipos de deducciones.";
            this.FileName = "CatNom12TipoDeduccion.json";
            this.Version = "3.0";
            this.Revision = "0";
        }

        public override CveTipoDeduccion Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null) return search;
            } catch (System.Exception) {

            }
            return new CveTipoDeduccion { Clave = query };
        }
    }
}
