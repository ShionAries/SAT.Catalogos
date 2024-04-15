// develop: 070720171730
// purpose: Catálogo de unidades de medida para los conceptos en el CFDI. Catalogo SAT

using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catálogo de colonias.
    /// </summary>
    public class ClaveColonia : ClaveBase, IClaveBase {
        [DataNames("CodigoPostal")]
        public string CodigoPostal { get; set; }
    }
}