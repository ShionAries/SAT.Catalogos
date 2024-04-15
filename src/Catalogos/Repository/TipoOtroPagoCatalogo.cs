using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de otro tipo pago (nomina)
    /// </summary>
    public class TipoOtroPagoCatalogo : CatalogoContext<ClaveTipoOtroPago>, ITipoOtroPagoCatalogo {
        public TipoOtroPagoCatalogo() {
            this.Title = "Catálogo de otro tipo de pago.";
            this.FileName = "CatalogoNominaTipoOtroPago.json";
            this.Version = "2";
        }
    }
}
