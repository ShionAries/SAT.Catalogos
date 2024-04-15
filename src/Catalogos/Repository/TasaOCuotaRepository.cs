using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class TasaOCuotaRepository : RepositoryContext<ClaveTasaOCuota>, ITasaOCuotaRepository, IGeneralRepository {
        public TasaOCuotaRepository() {
            this.Title = "Catálogo de tasas o cuotas de impuestos.";
            this.FileName = "CatalogoTasaOCuota.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
