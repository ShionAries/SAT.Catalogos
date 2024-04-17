using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Repositories {
    /// <summary>
    /// catalogo de otro tipo pago (nomina)
    /// </summary>
    public class TipoOtroPagoRepository : RepositoryContext<ClaveTipoOtroPago>, ITipoOtroPagoRepository, IGeneralRepository {
        public TipoOtroPagoRepository() {
            this.Title = "Catálogo de otro tipo de pago.";
            this.FileName = "CatalogoNominaTipoOtroPago.json";
            this.Version = "2";
        }
    }
}
