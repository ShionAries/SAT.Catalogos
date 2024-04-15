using System.Collections.Generic;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionPeriodicidadCatalogo : CatalogoContext<ClaveRetencionPeriodicidad>, IRetencionPeriodicidadCatalogo {
        public RetencionPeriodicidadCatalogo() {
            this.Title = "Catálogo de periodicidad Retenciones";
            this.FileName = "CatalogoPeriodicidad.json";
            this.Version = "1.0";
            this.Revision = "0";

            this.Items = new List<ClaveRetencionPeriodicidad>();
            this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "01", Descripcion = "Semanal", VigenciaIni = new System.DateTime(2019, 01, 06) });
            this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "02", Descripcion = "Mensual", VigenciaIni = new System.DateTime(2019, 01, 06) });
        }
    }
}
