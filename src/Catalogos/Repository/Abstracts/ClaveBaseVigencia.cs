using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    /// <summary>
    /// Clave de catalogo contiene clave, descripcion y fechas de vigencia
    /// </summary>
    public class ClaveBaseVigencia : ClaveBase {
        #region declaraciones
        private DateTime? fechaInicioVigenciaField;
        private bool fechaInicioVigenciaFieldSpecified;
        private DateTime? fechaFinVigenciaField;
        private bool fechaFinVigenciaFieldSpecified;
        #endregion

        public ClaveBaseVigencia() {
            VigenciaIni = null;
            VigenciaFin = null;
        }

        [Description("Fecha inicio de vigencia")]
        [DisplayName("Fecha inicio de vigencia")]
        [JsonIgnore]
        [DataNames("VigenciaIni")]
        public DateTime? VigenciaIni {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (fechaInicioVigenciaField >= firstGoodDate) {
                    return fechaInicioVigenciaField;
                } else {
                    return null;
                }
            }
            set {
                fechaInicioVigenciaField = value;
                fechaInicioVigenciaFieldSpecified = true;
            }
        }

        [Description("Fecha fin de vigencia")]
        [DisplayName("Fecha fin de vigencia")]
        [JsonIgnore]
        [DataNames("VigenciaFin")]
        public DateTime? VigenciaFin {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (fechaFinVigenciaField >= firstGoodDate) {
                    return fechaFinVigenciaField;
                } else {
                    return null;
                }
            }
            set {
                fechaFinVigenciaField = value;
                fechaFinVigenciaFieldSpecified = true;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool InicioVigenciaSpecified {
            get {
                return fechaInicioVigenciaFieldSpecified;
            }
            set {
                fechaInicioVigenciaFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public bool FinVigenciaSpecified {
            get {
                return fechaFinVigenciaFieldSpecified;
            }
            set {
                fechaFinVigenciaFieldSpecified = value;
            }
        }

        [Browsable(false)]
        [JsonProperty("vigi", Order = 10)]
        public string InicioVigenciaX {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (fechaInicioVigenciaField >= firstGoodDate) {
                    return fechaInicioVigenciaField.Value.ToString("yyyy-MM-dd");
                } else {
                    return null;
                }
            }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    fechaInicioVigenciaField = Convert.ToDateTime(value);
                }
            }
        }

        [Browsable(false)]
        [JsonProperty("vigf", Order = 15)]
        public string FinVigenciaX {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (fechaFinVigenciaField >= firstGoodDate) {
                    return fechaFinVigenciaField.Value.ToString("yyyy-MM-dd");
                } else {
                    return null;
                }
            }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    fechaFinVigenciaField = Convert.ToDateTime(value);
                }
            }
        }
    }
}
