using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Repositories {
    public class TipoJornadaCatalogo : CatalogoContext<ClaveTipoJornada>, ITipoJornadaCatalogo {
        public TipoJornadaCatalogo() {
            this.Title = "Catálogo de tipos de jornada laboral.";
            this.FileName = "CatalogoNominaTipoJornada.json";
            this.Version = "1.0";
            this.Revision = "A";
        }
    }
}
