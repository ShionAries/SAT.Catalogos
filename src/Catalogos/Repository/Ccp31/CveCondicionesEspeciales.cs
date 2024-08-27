using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catalogo de Condiciones Especiales del Transporte
    /// </summary>
    [JsonObject("item")]
    public class CveCondicionesEspeciales : ClaveBaseVigencia, IClaveBase { }
}
