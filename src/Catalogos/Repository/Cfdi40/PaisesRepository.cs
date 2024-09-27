using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de paises
    /// </summary>
    public class PaisesRepository : RepositoryContext<CvePais>, IPaisesRepository, IGeneralRepository {
        public PaisesRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de Paises";
            FileName = "PaisesCFDI40.json";
            Version = "1.0";
            this.AddLastVersion(lastUpdate);
        }

        public CvePais Search(string findId) {
            CvePais objeto = new CvePais();
            objeto = Items.SingleOrDefault((p) => p.Clave == findId);
            return objeto;
        }
    }
}
