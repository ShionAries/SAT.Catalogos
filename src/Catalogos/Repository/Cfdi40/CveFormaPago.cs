using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0, Catalogo de Formas de Pago
    /// </summary>
    [JsonObject("item")]
    public class CveFormaPago : Abstracts.ClaveBaseVigencia {

        public CveFormaPago() : base() { }

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

        /// <summary>
        /// clave en formato de dos digitos, para que sea compatible con la version 3.3 del CFDI
        /// </summary>
        [DisplayName("Clave")]
        [JsonProperty("clv", Order = 0)]
        [DataNames("Clave")]
        public new string Clave {
            get {
                var numero = int.Parse(base.Clave);
                return numero.ToString("00");
            }
            set { 
                base.Clave = int.Parse(value).ToString("00");
            }
        }
    }
}
