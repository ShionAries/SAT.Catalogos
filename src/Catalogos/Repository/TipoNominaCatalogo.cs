using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de tipos de nomina
    /// </summary>
    public class TipoNominaCatalogo : CatalogoContext<ClaveTipoNomina> {
        public TipoNominaCatalogo() {
            this.Title = "Catálogo de tipos de nómina.";
            this.FileName = "CatalogoNominaTipos.json";
        }
    }
}
