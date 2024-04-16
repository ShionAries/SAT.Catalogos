// develop: 210120180127
// purpose: Clave de pais, catalogo SAT

// develop: 210120180127
// purpose: Clave de pais, catalogo SAT
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    public class CveTipoEstacion : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("ClaveTransporte")]
        public string ClaveTransporte { get; set; }
    }
}
