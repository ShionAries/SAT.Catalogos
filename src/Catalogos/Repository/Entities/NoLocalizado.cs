using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Entities {
    public class NoLocalizado : BasePropertyChangeImplementation {
        private string rfc;
        private string razonSocial;
        private string tipoPersona;
        private DateTime? fecha1Publicacion;
        private string supuesto;

        /// <summary>
        /// obtener o establecer el registro federal de contribuyentes
        /// </summary>
        [JsonProperty("rfc")]
        public string RFC {
            get {
                return this.rfc;
            }
            set {
                this.rfc = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer la razon social del contribuyente
        /// </summary>
        [DisplayName("Razon Social")]
        [JsonProperty("rso")]
        public string RazonSocial {
            get {
                return this.razonSocial;
            }
            set {
                this.razonSocial = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer el tipo de persona moral o fisica
        /// </summary>
        [DisplayName("Tipo de Persona")]
        [JsonProperty("tipo")]
        public string TipoPersona {
            get {
                return this.tipoPersona;
            }
            set {
                this.tipoPersona = value;
                this.OnPropertyChanged();
            }
        }

        [JsonProperty("supuesto")]
        public string Supuesto {
            get {
                return this.supuesto;
            }
            set {
                this.supuesto = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer la fecha de la primera publicacion
        /// </summary>
        [JsonIgnore]
        [DisplayName("Fecha de primea publicación")]
        public DateTime? Fecha1Publicacion {
            get {
                return this.fecha1Publicacion;
            }
            set {
                this.fecha1Publicacion = value;
                this.OnPropertyChanged();
            }
        }

        [Browsable(false)]
        [JsonProperty("fec1pub")]
        public string Fecha1PublicacionX {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.fecha1Publicacion >= firstGoodDate)
                    return this.fecha1Publicacion.Value.ToString("yyyy-MM-dd");
                return null;
            }
            set {
                this.fecha1Publicacion = Convert.ToDateTime(value);
                this.OnPropertyChanged();
            }
        }
    }
}
