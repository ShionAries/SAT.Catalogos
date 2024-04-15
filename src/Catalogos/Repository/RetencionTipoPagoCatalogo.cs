using System.Collections.Generic;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionTipoPagoCatalogo : CatalogoContext<ClaveRetencionTipoPago>, IRetencionTipoPagoCatalogo {
        public RetencionTipoPagoCatalogo() {
            this.Items = new List<ClaveRetencionTipoPago>();
            this.Items.Add(new ClaveRetencionTipoPago { Clave = "Pago definitivo", Descripcion = "Pago definitivo" });
            this.Items.Add(new ClaveRetencionTipoPago { Clave = "Pago provisional", Descripcion = "Pago provisional" });
        }
    }
}
