using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de municipios.
    /// </summary>
    public class CveMunicipio : ClaveBaseVigencia, IClaveBase {
        [DataNames("Estado")]
        public string Estado { get; set; }
    }
}