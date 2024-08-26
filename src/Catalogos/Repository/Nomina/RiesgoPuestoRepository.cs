using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    public class RiesgoPuestoRepository : RepositoryContext<CveRiesgoPuesto>, IRiesgoPuestoRepository, IGeneralRepository {
        public RiesgoPuestoRepository() {
            Title = "Catálogo de clases en que deben inscribirse los patrones.";
            FileName = "CatalogoNominaRiesgoPuesto.json";
            Version = "2.0";
        }
    }
}
