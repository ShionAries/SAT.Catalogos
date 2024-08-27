using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0, Tipo de Materia
    /// </summary>
    [JsonObject("item")]
    public class CveTipoMateria : ClaveBaseVigencia, IClaveBase { }
}
