using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de regimen de contratacion
    /// </summary>
    public class TipoRegimenContratacionRepository : RepositoryContext<CveTipoRegimen>, ITipoRegimenContratacionRepository, IGeneralRepository {
        public TipoRegimenContratacionRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo de tipos de régimen de contratación.";
            this.FileName = "CatNom12TipoRegimenContratacion.json";
            this.Version = "2.0";
            this.Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoRegimen Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                return search;
            } catch (System.Exception) {

            }
            return new CveTipoRegimen { Clave = query };
        }
    }
}
