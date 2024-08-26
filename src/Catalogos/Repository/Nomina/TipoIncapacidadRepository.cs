using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// catalogo del tipo de incapacidad
    /// </summary>
    public class TipoIncapacidadRepository : RepositoryContext<CveTipoIncapacidad>, ITipoIncapacidadRepository, IGeneralRepository {
        public TipoIncapacidadRepository() {
            this.Title = "Catálogo del tipo de incapacidad.";
            this.FileName = "CatalogoNominaTipoIncapacidad.json";
            this.Version = "1.0";
        }
    }
}
