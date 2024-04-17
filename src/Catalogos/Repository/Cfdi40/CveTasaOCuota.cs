using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Repository.ValueObjects;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// CFDI 4.0: Catálogo de tasas o cuotas de impuestos.
    /// </summary>
    [JsonObject("item")]
    public class CveTasaOCuota : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        //private EnumFactor factorField;
        private bool valorMinimoFieldSpecified;
        //private bool trasladoField;
        //private bool retencionField;
        private decimal valorMinimoField;
        private decimal valorMaximoField;
        private string impuestoField;

        [DisplayName("Rango ó Fijo")]
        [JsonProperty("rng")]
        [DataNames("RangoOFijo")]
        public string RangoOFijo { get; set; }

        [JsonIgnore]
        public EnumRangoOFijo IsRangoOFijo {
            get { return (EnumRangoOFijo)Enum.Parse(typeof(EnumRangoOFijo), RangoOFijo); }
        }

        [DisplayName("Valor mínimo")]
        [JsonProperty("min")]
        [DataNames("ValorMinimo")]
        public decimal ValorMinimo {
            get {
                return valorMinimoField;
            }
            set {
                valorMinimoField = value;
            }
        }

        [DisplayName("Valor máximo")]
        [JsonProperty("max")]
        [DataNames("ValorMaximo")]
        public decimal ValorMaximo {
            get {
                return valorMaximoField;
            }
            set {
                valorMaximoField = value;
            }
        }

        [DisplayName("Impuesto")]
        [JsonProperty("imp")]
        [DataNames("Impuesto")]
        public string Impuesto {
            get {
                return impuestoField;
            }
            set {
                impuestoField = value;
            }
        }

        [DisplayName("Factor")]
        [JsonProperty("fac")]
        [DataNames("Factor")]
        public string Factor { get; set; }

        public EnumFactor IsFactor {
            get { return (EnumFactor)Enum.Parse(typeof(EnumFactor), Factor); }
        }

        [DisplayName("Traslado")]
        [JsonProperty("tra")]
        [DataNames("Traslado")]
        public string Traslado { get; set; }

        [DisplayName("Retención")]
        [JsonProperty("ret")]
        [DataNames("Retención")]
        public string Retencion { get; set; }

        [Browsable(false)]
        [JsonIgnore]
        public bool ValorMinimoSpecified {
            get {
                return valorMinimoFieldSpecified;
            }
            set {
                valorMinimoFieldSpecified = value;
            }
        }
    }
}