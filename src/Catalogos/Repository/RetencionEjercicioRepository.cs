using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionEjercicioRepository : RepositoryContext<ClaveRetencionEjercicio>, IRetencionEjercicioRepository, IGeneralRepository {
        public RetencionEjercicioRepository() {
            this.Title = "Retenciones: Catálogo Ejercicio";
            this.FileName = "CatalogoPeriodicidad.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
