using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions; 

namespace Jaeger.Catalogos.Repositories {
    public class TipoDeduccionCatalogo : CatalogoContext<ClaveTipoDeduccion>, ITipoDeduccionCatalogo {
        public TipoDeduccionCatalogo() {
            this.Title = "Catálogo de tipos de deducciones.";
            this.FileName = "CatalogoTipoDeduccion.json";
            this.Version = "3.0";
            this.Revision = "0";
        }
    }
}
