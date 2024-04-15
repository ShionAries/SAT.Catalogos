using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de tipos de contrato (nomina)
    /// </summary>
    public class TipoContratoCatalogo : CatalogoContext<ClaveTipoContrato>, ITipoContratoCatalogo {
        public TipoContratoCatalogo() {
            this.Title = "Catálogo de tipos de contrato";
            this.FileName = "CatalogoNominaTipoContrato.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
