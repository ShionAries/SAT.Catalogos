using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class RiesgoPuestoRepository : RepositoryContext<ClaveRiesgoPuesto>, IRiesgoPuestoRepository, IGeneralRepository {
        public RiesgoPuestoRepository() {
            Title = "Catálogo de clases en que deben inscribirse los patrones.";
            FileName = "CatalogoNominaRiesgoPuesto.json";
            Version = "2.0";
        }
    }
}
