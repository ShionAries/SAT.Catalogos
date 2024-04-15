using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Repository.ValueObjects;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// CFDI: Catálogo de tasas o cuotas de impuestos.
    /// </summary>
    [JsonObject("item")]
    public class ClaveTasaOCuota : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        private EnumFactor factorField;
        private bool valorMinimoFieldSpecified;
        private bool trasladoField;
        private bool retencionField;
        private decimal valorMinimoField;
        private decimal valorMaximoField;
        private string impuestoField;

        [DisplayName("Rango ó Fijo")]
        [JsonProperty("rng")]
        [DataNames("RangoOFijo")]
        public string RangoOFijo { get; set; }

        [JsonIgnore]
        public EnumRangoOFijo IsRangoOFijo {
            get { return (EnumRangoOFijo)Enum.Parse(typeof(EnumRangoOFijo), this.RangoOFijo); }
        }

        [DisplayName("Valor mínimo")]
        [JsonProperty("min")]
        [DataNames("ValorMinimo")]
        public decimal ValorMinimo {
            get {
                return this.valorMinimoField;
            }
            set {
                this.valorMinimoField = value;
            }
        }

        [DisplayName("Valor máximo")]
        [JsonProperty("max")]
        [DataNames("ValorMaximo")]
        public decimal ValorMaximo {
            get {
                return this.valorMaximoField;
            }
            set {
                this.valorMaximoField = value;
            }
        }

        [DisplayName("Impuesto")]
        [JsonProperty("imp")]
        [DataNames("Impuesto")]
        public string Impuesto {
            get {
                return this.impuestoField;
            }
            set {
                this.impuestoField = value;
            }
        }

        [DisplayName("Factor")]
        [JsonProperty("fac")]
        [DataNames("Factor")]
        public string Factor { get; set; }

        public EnumFactor IsFactor {
            get { return (EnumFactor)Enum.Parse(typeof(EnumFactor), this.Factor); }
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
                return this.valorMinimoFieldSpecified;
            }
            set {
                this.valorMinimoFieldSpecified = value;
            }
        }
    }
}