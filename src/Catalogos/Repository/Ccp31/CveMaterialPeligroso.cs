// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0, Catálogo de materiales peligrosos.
    /// </summary>
    public class CveMaterialPeligroso : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("Clase")]
        public string Clase { get; set; }

        [DataNames("PeligroSecundario")]
        public string PeligroSecundario { get; set; }

        [DataNames("NombreTecnico")]
        public string NombreTecnico { get; set; }
    }
}
