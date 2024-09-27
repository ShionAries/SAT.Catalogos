using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    public class RiesgoPuestoRepository : RepositoryContext<CveRiesgoPuesto>, IRiesgoPuestoRepository, IGeneralRepository {
        public RiesgoPuestoRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de clases en que deben inscribirse los patrones.";
            FileName = "CatNom12RiesgoPuesto.json";
            Version = "2.0";
            this.AddLastVersion(lastUpdate);
        }
    }
}
