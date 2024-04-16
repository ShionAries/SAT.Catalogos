using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public class CveTipoPermiso : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("ClaveTransporte")]
        public string ClaveTransporte { get; set; }
    }
}
