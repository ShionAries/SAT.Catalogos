using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de tipos de percepciones
    /// </summary>
    public class TipoPercepcionCatalogo : CatalogoContext<ClaveTipoPercepcion>, ITipoPercepcionCatalogo {
        public TipoPercepcionCatalogo() {
            this.Title = "Catálogo de tipos de percepciones.";
            this.FileName = "CatalogoTipoPercepcion.json";
            this.Version = "2.0";
            this.Revision = "0";
        }
    }
}
