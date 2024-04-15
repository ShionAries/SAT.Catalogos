using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// clase de catálogo base para contener información 
    /// </summary>
    /// <typeparam name="T">objeto clase T</typeparam>
    public partial class CatalogoBase<TObject> {
        private DateTime? actualizacionField;
        private DateTime? inicioVigencia;
        private DateTime? finVigencia;

        /// <summary>
        /// constructor
        /// </summary>
        public CatalogoBase() {
            this.Version = "1.0";
            this.Titulo = "Catálogo";
            this.Revision = "0";
            this.Actualizacion = DateTime.Now;
            this.Items = new List<TObject>();
        }

        /// <summary>
        /// obtener o establecer version del catalogo
        /// </summary>
        [JsonProperty("ver", Order = 1)]
        public string Version { get; set; }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        [JsonProperty("titulo", Order = 2)]
        public string Titulo { get; set; }

        /// <summary>
        /// obtener o establecer numero de revision del catalogo
        /// </summary>
        [JsonProperty("rev", Order = 3)]
        public string Revision { get; set; }

        /// <summary>
        /// obtener o establecer fecha de inicio de vigencia del catalogo
        /// </summary>
        [JsonProperty("vigi", Order = 5)]
        public DateTime? VigenciaIni {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.inicioVigencia >= firstGoodDate)
                    return this.inicioVigencia;
                return null;
            }
            set {
                this.inicioVigencia = value;
            }
        }

        /// <summary>
        /// obtener o establecer fecha de fin de vigencia
        /// </summary>
        [JsonProperty("vigf", Order = 6)]
        public DateTime? VigenciaFin {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.finVigencia >= firstGoodDate)
                    return this.finVigencia;
                return null;
            }
            set {
                this.finVigencia = value;
            }
        }

        /// <summary>
        /// obtener o establecer fecha de actualización del catalogo
        /// </summary>
        [JsonProperty("act", Order = 4)]
        public DateTime? Actualizacion {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (this.actualizacionField >= firstGoodDate)
                    return this.actualizacionField;
                return null;
            }
            set {
                this.actualizacionField = value;
            }
        }

        [JsonProperty("items", Order = 7)]
        public List<TObject> Items { get; set; }

        public string ToJson(Formatting formatting = 0) {
            // configuracion json para la serializacion
            var conf = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd/MM/yyyy" };
            return JsonConvert.SerializeObject(this, formatting, conf);
        }
    }
}
