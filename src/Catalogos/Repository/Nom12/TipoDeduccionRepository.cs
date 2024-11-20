using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina Catalogo de tipos de deducciones
    /// </summary>
    public class TipoDeduccionRepository : RepositoryContext<CveTipoDeduccion>, ITipoDeduccionRepository, IRepositoryGeneric {
        public TipoDeduccionRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de tipos de deducciones.";
            FileName = "CatNom12TipoDeduccion.json";
            Version = "3.0";
            Revision = "0";
            this.AddLastUpdate(lastUpdate);
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
