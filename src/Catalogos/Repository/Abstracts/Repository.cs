using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    /// <summary>
    /// Clase de catálogo base para contener metadatos y colección de objetos.
    /// </summary>
    /// <typeparam name="TObject">Tipo de objeto que contiene el catálogo.</typeparam>
    public class Repository<TObject> : RepositoryBase {
        #region Campos Privados

        private DateTime? _inicioVigencia;
        private DateTime? _finVigencia;
        private DateTime? _lastUpdate;

        #endregion

        #region Constructor

        public Repository() {
            Version = "1.0";
            Title = "Catálogo";
            Revision = "0";
            Builder = Assembly.GetExecutingAssembly().GetName().Name;
            LastUpdate = DateTime.Now;
            Items = new List<TObject>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece la versión del catálogo.
        /// </summary>
        [JsonProperty("ver", Order = 1)]
        public string Version { get; set; }

        /// <summary>
        /// Obtiene o establece el título del catálogo.
        /// </summary>
        [JsonProperty("titulo", Order = 2)]
        public string Title { get; set; }

        /// <summary>
        /// Obtiene o establece el número de revisión del catálogo.
        /// </summary>
        [JsonProperty("rev", Order = 3)]
        public string Revision { get; set; }

        /// <summary>
        /// Obtiene o establece el ensamblado/generador del catálogo.
        /// </summary>
        [JsonProperty("builder", Order = 4)]
        public string Builder { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio de vigencia del catálogo.
        /// </summary>
        [JsonProperty("vigi", Order = 5)]
        public DateTime? VigenciaIni {
            get { return NormalizeDate(_inicioVigencia); }
            set { _inicioVigencia = value; }
        }

        /// <summary>
        /// Obtiene o establece la fecha de fin de vigencia del catálogo.
        /// </summary>
        [JsonProperty("vigf", Order = 6)]
        public DateTime? VigenciaFin {
            get { return NormalizeDate(_finVigencia); }
            set { _finVigencia = value; }
        }

        /// <summary>
        /// Obtiene o establece la fecha de última actualización del catálogo.
        /// </summary>
        [JsonProperty("act", Order = 7)]
        public DateTime? LastUpdate {
            get { return NormalizeDate(_lastUpdate); }
            set { _lastUpdate = value; }
        }

        /// <summary>
        /// Colección de elementos contenidos en el catálogo.
        /// </summary>
        [JsonProperty("items", Order = 99)]
        public List<TObject> Items { get; set; }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Serializa el catálogo actual a formato JSON.
        /// </summary>
        /// <param name="formatting">Formato de salida (Indented o None).</param>
        /// <returns>Cadena formateada en JSON.</returns>
        public string ToJson(Formatting formatting = Formatting.None) {
            return JsonConvert.SerializeObject(this, formatting, _jsonSettings);
        }

        #endregion
    }
}