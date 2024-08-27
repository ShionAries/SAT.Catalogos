using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de número autorización agente naviero consignatario. 
    /// </summary>
    public class CveNumAutorizacionNaviero : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        [DataNames("NumAutorizacion")]
        public string NumAutorizacion { get; set; }
    }
}
