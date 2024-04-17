using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Metodo de Pago
    /// </summary>
    [JsonObject("item")]
    public class CveMetodoPago : ClaveBaseVigencia, IClaveBaseItem {
        public CveMetodoPago() : base() { }
    }
}