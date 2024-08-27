using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de clave de tipo de estacion
    /// </summary>
    public class CveTipoEstacion : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("ClaveTransporte")]
        public string ClaveTransporte { get; set; }
    }
}
