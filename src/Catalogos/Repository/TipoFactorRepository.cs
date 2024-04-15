using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo tipo de factor para impuestos en CFDI 3.3
    /// </summary>
    public class TipoFactorRepository : RepositoryContext<ClaveTipoFactor>, ITipoFactorRepository, IGeneralRepository {
        public TipoFactorRepository() {
            this.Title = "Catálogo tipo factor";
            this.FileName = "CatalogoTipoFactor.json";
            this.Version = "1.0";
            this.Revision = "0";
        }

        public ClaveTipoFactor Search(string findId) {
            throw new System.NotImplementedException();
        }
    }
}
