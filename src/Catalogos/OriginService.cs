using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para servicio de origenes
    /// </summary>
    public class OriginService : OriginsTranslator, IOriginService {
        /// <summary>
        /// constructor
        /// </summary>
        public OriginService(IConfiguration configuration) : base() {
            Configuration = configuration;
        }

        /// <summary>
        /// constructor
        /// </summary>
        public OriginService() : base() {
            Configuration = new Configuration();
        }

        /// <summary>
        /// obtener o establecer control de layout
        /// </summary>
        public ControlLayout Control { get; set; }

        /// <summary>
        /// obtener o establecer configuracion
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// obtener o establecer lista de origines de datos
        /// </summary>
        public List<IOrigin> DataSource { get; set; }

        /// <summary>
        /// obtener listado de origenes
        /// </summary>
        public IOriginService GetAll() {
            this.Control = OriginsFromString();
            if (this.Control == null) {
                this.Control = new ControlLayout {
                    Configuration = (Configuration)this.Configuration
                };
            }
            this.DataSource = OriginFromLayout(this.Control.Origins);
            return this;
        }

        /// <summary>
        /// almacenar datos
        /// </summary>
        public IOriginService Save() {
            this.WriteFile();
            return this;
        }

        #region builder
        /// <summary>
        /// obtener ruta completa del archivo de control
        /// </summary>
        /// <returns></returns>
        protected string BuildPath() {
            return Path.Combine(Configuration.WorkingFolder, Configuration.FileName);
        }

        protected ControlLayout ReadOrigin(string content) {
            var configuration = new JsonSerializerSettings() {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd/MM/yyyy"
            };

            try {
                return JsonConvert.DeserializeObject<ControlLayout>(content, configuration);
            } catch (System.Exception ex) {
                System.Console.WriteLine(ex.Message);
            }
            return null;
        }

        protected ControlLayout OriginsFromString() {
            if (!File.Exists(BuildPath())) { return null; }
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            return ReadOrigin(File.ReadAllText(BuildPath(), utf8WithoutBom));
        }

        protected void WriteFile() {
            var configuration = new JsonSerializerSettings() {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd/MM/yyyy"
            };

            this.Control = new ControlLayout {
                Configuration = (Configuration)this.Configuration,
                Origins = OriginToLayout(DataSource)
            };
            var contenido = JsonConvert.SerializeObject(this.Control, Formatting.Indented, configuration);
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(BuildPath(), contenido, utf8WithoutBom);
        }
        #endregion
    }
}
    