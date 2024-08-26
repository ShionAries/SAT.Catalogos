using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de colonias, tambien utilizado en el complemento carta porte 3.0
    /// </summary>
    [JsonObject("item")]
    public class CveColonia : ClaveBase, IClaveBase {
        public CveColonia() { }

        [DataNames("CodigoPostal")]
        public string CodigoPostal { get; set; }
    }
}