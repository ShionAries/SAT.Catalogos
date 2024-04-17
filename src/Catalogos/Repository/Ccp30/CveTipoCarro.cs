using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de tipo de carro.
    /// </summary>
    public class CveTipoCarro : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("Contenedor")]
        public int Contenedor { get; set; }
    }
}
