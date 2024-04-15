/// develop: anhe 17072019 1425
/// purpose: catalogo de tipos de cadena de pago aplicables para los complementos de comprobante de pagos.
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class TipoCadenaPagoCatalogo : CatalogoContext<ClaveTipoCadenaPago>, ITipoCadenaPagoCatalogo {
        public TipoCadenaPagoCatalogo() {
            this.Title = "Catálogo de tipo de la cadena de pago.";
            this.FileName = "CatalogoTipoCadenaPago.json";
        }
    }
}
