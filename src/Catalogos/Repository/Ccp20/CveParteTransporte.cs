using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Carta Porte 3.0, Catálogo de partes del transporte rentadas o prestadas.
    /// </summary>
    [JsonObject("item")]
    public class CveParteTransporte : ClaveBaseVigencia, IClaveBaseItem { }
}
