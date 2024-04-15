using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    /// <summary>
    /// Clave de catalogo, solo contiene fechas de vigencia
    /// </summary>
    public abstract class ClaveBaseVigenciaSingle : IClaveBaseVigencia {
        private DateTime? fechaInicioVigenciaField;
        private bool fechaInicioVigenciaFieldSpecified;
        private DateTime? fechaFinVigenciaField;
        private bool fechaFinVigenciaFieldSpecified;

        public ClaveBaseVigenciaSingle() {
            this.VigenciaIni = null;
            this.VigenciaFin = null;
        }

        [Description("Fecha inicio de vigencia")]
        [DisplayName("Fecha inicio de vigencia")]
        [JsonIgnore]
        [DataNames("VigenciaIni")]
        public DateTime? VigenciaIni {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.fechaInicioVigenciaField >= firstGoodDate) {
                    return this.fechaInicioVigenciaField;
                } else {
                    return null;
                }
            }
            set {
                this.fechaInicioVigenciaField = value;
                this.fechaInicioVigenciaFieldSpecified = true;
            }
        }

        [Description("Fecha fin de vigencia")]
        [DisplayName("Fecha fin de vigencia")]
        [JsonIgnore]
        [DataNames("VigenciaFin")]
        public DateTime? VigenciaFin {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.fechaFinVigenciaField >= firstGoodDate) {
                    return this.fechaFinVigenciaField;
                } else {
                    return null;
                }
            }
            set {
                this.fechaFinVigenciaField = value;
                this.fechaFinVigenciaFieldSpecified = true;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool InicioVigenciaSpecified {
            get {
                return this.fechaInicioVigenciaFieldSpecified;
            }
            set {
                this.fechaInicioVigenciaFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FinVigenciaSpecified {
            get {
                return this.fechaFinVigenciaFieldSpecified;
            }
            set {
                this.fechaFinVigenciaFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonProperty("vigi", Order = 98)]
        public string InicioVigenciaX {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.fechaInicioVigenciaField >= firstGoodDate) {
                    return this.fechaInicioVigenciaField.Value.ToString("yyyy-MM-dd");
                } else {
                    return null;
                }
            }
            set {
                this.fechaInicioVigenciaField = Convert.ToDateTime(value);
            }
        }

        [Browsable(false)]
        [JsonProperty("vigf", Order = 99)]
        public string FinVigenciaX {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.fechaFinVigenciaField >= firstGoodDate) {
                    return this.fechaFinVigenciaField.Value.ToString("yyyy-MM-dd");
                } else {
                    return null;
                }
            }
            set {
                this.fechaFinVigenciaField = Convert.ToDateTime(value);
            }
        }
    }
}
