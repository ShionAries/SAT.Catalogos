using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    /// <summary>
    /// clase de catálogo base para contener información 
    /// </summary>
    /// <typeparam name="T">objeto clase T</typeparam>
    public class Repository<TObject> {
        #region variables
        private DateTime? _LastUpdate;
        private DateTime? _InicioVigencia;
        private DateTime? _FinVigencia;
        private string _Builder;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public Repository() {
            Version = "1.0";
            Title = "Catálogo";
            Revision = "0";
            _Builder = Assembly.GetExecutingAssembly().GetName().ToString();
            LastUpdate = DateTime.Now;
            Items = new List<TObject>();
        }

        #region propiedades
        /// <summary>
        /// obtener o establecer version del catalogo
        /// </summary>
        [JsonProperty("ver", Order = 1)]
        public string Version { get; set; }

        /// <summary>
        /// obtener o establecer titulo del catalogo
        /// </summary>
        [JsonProperty("titulo", Order = 2)]
        public string Title { get; set; }

        /// <summary>
        /// obtener o establecer numero de revision del catalogo
        /// </summary>
        [JsonProperty("rev", Order = 3)]
        public string Revision { get; set; }

        /// <summary>
        /// obtener o establecer
        /// </summary>
        [JsonProperty("builder", Order = 4)]
        public string Builder {
            get { return this._Builder; }
        }

        /// <summary>
        /// obtener o establecer fecha de inicio de vigencia del catalogo
        /// </summary>
        [JsonProperty("vigi", Order = 5)]
        public DateTime? VigenciaIni {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (_InicioVigencia >= firstGoodDate)
                    return _InicioVigencia;
                return null;
            }
            set {
                _InicioVigencia = value;
            }
        }

        /// <summary>
        /// obtener o establecer fecha de fin de vigencia
        /// </summary>
        [JsonProperty("vigf", Order = 6)]
        public DateTime? VigenciaFin {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                if (_FinVigencia >= firstGoodDate)
                    return _FinVigencia;
                return null;
            }
            set {
                _FinVigencia = value;
            }
        }

        /// <summary>
        /// obtener o establecer fecha de actualización del catalogo
        /// </summary>
        [JsonProperty("act", Order = 7)]
        public DateTime? LastUpdate {
            get {
                if (_LastUpdate >= new DateTime(1900, 1, 1))
                    return _LastUpdate;
                return null;
            }
            set {
                _LastUpdate = value;
            }
        }

        [JsonProperty("items", Order = 99)]
        public List<TObject> Items { get; set; }
        #endregion

        #region metodos publicos
        public string ToJson(Formatting formatting = 0) {
            // configuracion json para la serializacion
            var conf = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd/MM/yyyy" };
            return JsonConvert.SerializeObject(this, formatting, conf);
        }
        #endregion
    }
}
