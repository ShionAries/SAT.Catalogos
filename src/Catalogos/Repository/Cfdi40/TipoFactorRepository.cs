using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo tipo de factor para impuestos en CFDI 3.3
    /// </summary>
    public class TipoFactorRepository : RepositoryContext<CveTipoFactor>, ITipoFactorRepository, IRepositoryGeneric {
        public TipoFactorRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo tipo factor";
            FileName = "TipoFactorCFD40.json";
            Version = "1.0";
            Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoFactor Search(string findId) {
            throw new System.NotImplementedException();
        }
    }
}
