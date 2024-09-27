using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo del tipo de incapacidad
    /// </summary>
    public class TipoIncapacidadRepository : RepositoryContext<CveTipoIncapacidad>, ITipoIncapacidadRepository, IGeneralRepository {
        public TipoIncapacidadRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo del tipo de incapacidad.";
            this.FileName = "CatNom12TipoIncapacidad.json";
            this.Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }
    }
}
