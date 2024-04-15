using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo de impuestos
    /// </summary>
    public class ImpuestosRepository : RepositoryContext<ClaveImpuesto>, IImpuestosRepository, IGeneralRepository {
        public ImpuestosRepository() {
            this.Title = "Catálogo de impuestos";
            this.FileName = "CatalogoImpuestos.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
