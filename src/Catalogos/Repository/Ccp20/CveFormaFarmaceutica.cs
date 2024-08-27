using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catalogo de Forma Farmaceutica
    /// </summary>
    [JsonObject("item")]
    public class CveFormaFarmaceutica : ClaveBaseVigencia, IClaveBase { }
}
