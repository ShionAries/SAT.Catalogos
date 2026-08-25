using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catálogo de colonias, tambien utilizado en el complemento carta porte 3.0
    /// </summary>
    [JsonObject("item")]
    public class CveColonia : Abstracts.ClaveBase, Interfaces.IClaveBase {
        public CveColonia() : base() { }

        [Helpers.Mapping.DataNames("CodigoPostal")]
        public string CodigoPostal { get; set; }
    }
}