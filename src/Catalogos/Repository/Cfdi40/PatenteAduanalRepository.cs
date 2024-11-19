using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de patentes aduanales
    /// </summary>
    public class PatenteAduanalRepository : RepositoryContext<CvePatenteAduanal>, IPatenteAduanalRepository, IGeneralRepository {
        public PatenteAduanalRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de patentes aduanales";
            FileName = "PatentesAduanalesCFDI40.json";
            Revision = "0";
            Version = "25.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CvePatenteAduanal Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    return new CvePatenteAduanal() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CvePatenteAduanal() { Clave = query };
        }
    }
}
