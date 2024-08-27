using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// CFDI 4.0, Catálogo de localidades. 
    /// </summary>
    public class CveLocalidad : ClaveBaseVigencia, IClaveBase {

        public CveLocalidad() : base() { }

        [DataNames("Estado")]
        public string Estado { get; set; }
    }
}