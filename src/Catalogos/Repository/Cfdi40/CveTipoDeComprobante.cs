using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0: Tipos de Comprobantes
    /// </summary>
    [JsonObject("item")]
    public class CveTipoDeComprobante : ClaveBaseVigencia, IClaveBaseItem {

        /// <summary>
        /// constructor
        /// </summary>
        public CveTipoDeComprobante() { }

        [Description("Valor Máximo")]
        [DisplayName("Valor Máximo")]
        [JsonProperty("max")]
        [DataNames("ValorMaximo")]
        public decimal ValorMaximo { get; set; }
    }
}