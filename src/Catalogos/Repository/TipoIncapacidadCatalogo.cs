using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Repositories {
    public class TipoIncapacidadCatalogo : CatalogoContext<ClaveTipoIncapacidad>, ITipoIncapacidadCatalogo {
        public TipoIncapacidadCatalogo() {
            this.Title = "Catálogo del tipo de incapacidad.";
            this.FileName = "CatalogoNominaTipoIncapacidad.json";
            this.Version = "1.0";
        }
    }
}
