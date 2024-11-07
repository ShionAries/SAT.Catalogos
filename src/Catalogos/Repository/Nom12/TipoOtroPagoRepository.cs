using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de otro tipo pago (nomina)
    /// </summary>
    public class TipoOtroPagoRepository : RepositoryContext<CveTipoOtroPago>, ITipoOtroPagoRepository, IGeneralRepository {
        public TipoOtroPagoRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo de otro tipo de pago.";
            this.FileName = "CatNom12TipoOtroPago.json";
            this.Version = "2";
            this.AddLastUpdate(lastUpdate);
        }
    }
}
