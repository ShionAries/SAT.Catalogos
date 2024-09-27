using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo tipo de factor para impuestos en CFDI 3.3
    /// </summary>
    public class TipoFactorRepository : RepositoryContext<CveTipoFactor>, ITipoFactorRepository, IGeneralRepository {
        public TipoFactorRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo tipo factor";
            FileName = "TipoFactorCFD40.json";
            Version = "1.0";
            Revision = "0";
            this.AddLastVersion(lastUpdate);
        }

        public CveTipoFactor Search(string findId) {
            throw new System.NotImplementedException();
        }
    }
}
