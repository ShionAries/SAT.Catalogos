using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class TipoIncapacidadRepository : RepositoryContext<ClaveTipoIncapacidad>, ITipoIncapacidadRepository, IGeneralRepository {
        public TipoIncapacidadRepository() {
            this.Title = "Catálogo del tipo de incapacidad.";
            this.FileName = "CatalogoNominaTipoIncapacidad.json";
            this.Version = "1.0";
        }
    }
}
