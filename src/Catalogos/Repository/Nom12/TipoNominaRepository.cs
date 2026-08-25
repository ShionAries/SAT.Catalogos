using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de nomina
    /// </summary>
    public class TipoNominaRepository : RepositoryContext<CveTipoNomina>, ITipoNominaRepository, Interfaces.IRepositoryGeneric {
        public TipoNominaRepository() : base() {
            this.Description = "Catálogo de tipos de nómina.";
            this.FileName = "CatNom12Tipos.json";
        }

        public override CveTipoNomina Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveTipoNomina { Clave = query };
        }
    }
}
