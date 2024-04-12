using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    [JsonObject("item")]
    public class ClaveFormaPago : ClaveBaseVigencia {
        [Description("Bancarizado")]
        [DisplayName("Bancarizado")]
        [JsonProperty("bancarizado")]
        [DataNames("Bancarizado")]
        public string Bancarizado { get; set; }

        [Description("Número de operación")]
        [DisplayName("Número de operación")]
        [JsonProperty("numOperacion")]
        [DataNames("NumOperacion")]
        public string NumOperacion { get; set; }

        [Description("RFC del Emisor de la cuenta ordenante")]
        [DisplayName("RFC del Emisor de la cuenta ordenante")]
        [JsonProperty("rfcEmisorCtaOrd")]
        [DataNames("RfcEmisorCtaOrdenante")]
        public string RfcEmisorCtaOrdenante { get; set; }

        [Description("Cuenta Ordenante")]
        [DisplayName("Cuenta Ordenante")]
        [JsonProperty("ctaOrdenante")]
        [DataNames("CtaOrdenante")]
        public string CtaOrdenante { get; set; }

        [Description("Patrón para cuenta ordenante")]
        [DisplayName("Patrón para cuenta ordenante")]
        [JsonProperty("patronCtaOrd")]
        [DataNames("PatronCtaOrdenante")]
        public string PatronCtaOrdenante { get; set; }

        [Description("RFC del Emisor Cuenta de Beneficiario")]
        [DisplayName("RFC del Emisor Cuenta de Beneficiario")]
        [JsonProperty("rfcEmisotBenef")]
        [DataNames("RfcEmisorCtaBeneficiario")]
        public string RfcEmisorCtaBeneficiario { get; set; }

        [Description("Cuenta de Benenficiario")]
        [DisplayName("Cuenta de Benenficiario")]
        [JsonProperty("ctaDelBenef")]
        [DataNames("CtaDelBeneficiario")]
        public string CtaDelBeneficiario { get; set; }

        [Description("Patrón para cuenta Beneficiaria")]
        [DisplayName("Patrón para cuenta Beneficiaria")]
        [JsonProperty("patronCtaBenef")]
        [DataNames("PatronCtaBeneficiaria")]
        public string PatronCtaBeneficiaria { get; set; }

        [Description("Tipo Cadena Pago")]
        [DisplayName("Tipo Cadena Pago")]
        [JsonProperty("tipoCadPago")]
        [DataNames("TipoCadenaPago")]
        public string TipoCadenaPago { get; set; }

        /// <summary>
        /// Nombre del Banco emisor de la cuenta ordenante en caso de extranjero
        /// </summary>
        [Description("Nombre del Banco emisor de la cuenta ordenante en caso de extranjero")]
        [DisplayName("Nombre del Banco Emisor Extranjero")]
        [JsonProperty("nombreBancoEmisorCtaOrdenante")]
        [DataNames("NombreBancoEmisorCtaOrdenante")]
        public string NombreBancoEmisorCtaOrdenante { get; set; }
    }
}
