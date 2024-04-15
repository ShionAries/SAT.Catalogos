using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Tipos de Comprobantes
    /// </summary>
    [JsonObject("item")]
    public class ClaveTipoDeComprobante : ClaveBaseVigencia, IClaveBaseItem {

        /// <summary>
        /// constructor
        /// </summary>
        public ClaveTipoDeComprobante() { }

        [Description("Valor Máximo")]
        [DisplayName("Valor Máximo")]
        [JsonProperty("max")]
        [DataNames("ValorMaximo")]
        public decimal ValorMaximo { get; set; }
    }
}