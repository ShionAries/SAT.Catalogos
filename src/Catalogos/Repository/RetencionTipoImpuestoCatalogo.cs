using System;
using System.Collections.Generic;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionTipoImpuestoCatalogo : CatalogoContext<ClaveRetencionTipoImpuesto>, IRetencionTipoImpuestoCatalogo {
        public RetencionTipoImpuestoCatalogo() {
            this.Items = new List<ClaveRetencionTipoImpuesto>();
            this.Items.Add(new ClaveRetencionTipoImpuesto { Clave = "01", Descripcion = "ISR", VigenciaIni = new DateTime(2015, 5, 22) });
            this.Items.Add(new ClaveRetencionTipoImpuesto { Clave = "02", Descripcion = "IVA", VigenciaIni = new DateTime(2015, 5, 22) });
            this.Items.Add(new ClaveRetencionTipoImpuesto { Clave = "03", Descripcion = "IEPS", VigenciaIni = new DateTime(2015, 5, 22) });
        }
    }
}
