using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0, Catálogo de tipo servicio.
    /// </summary>
    public class CveTipoDeServicio : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("Contenedor")]
        public int Contenedor { get; set; }
    }
}
