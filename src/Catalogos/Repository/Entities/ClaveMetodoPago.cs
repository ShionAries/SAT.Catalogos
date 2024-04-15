using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Catalogo de Metodo de Pago
    /// </summary>
    [JsonObject("item")]
    public class ClaveMetodoPago : ClaveBaseVigencia, IClaveBaseItem {
        public ClaveMetodoPago() : base() { }
    }
}