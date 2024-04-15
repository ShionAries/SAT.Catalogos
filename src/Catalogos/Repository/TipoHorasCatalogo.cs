using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de tipos de horas extra (nomina)
    /// </summary>
    public class TipoHorasCatalogo : CatalogoContext<ClaveTipoHoras>, ITipoHorasCatalogo {
        public TipoHorasCatalogo() {
            this.Title = "Catálogo de tipos de Hora Extra.";
            this.FileName = "CatalogoNominaTipoHoras.json";
            this.Version = "1.0";
        }
    }
}
