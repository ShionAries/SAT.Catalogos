using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de retenciones
    /// </summary>
    public class RetencionesCatalogo : CatalogoContext<ClaveRetencion>, IRetencionesCatalogo {
        public RetencionesCatalogo() {
            this.Title = "Catálogo de Retenciones";
            this.FileName = "CatalogoRetenciones.json";
        }
    }
}
