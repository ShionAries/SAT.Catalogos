using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// clase para servicio de origenes
    /// </summary>
    public class OriginService : OriginsTranslator, IOriginService {

        /// <summary>
        /// constructor
        /// </summary>
        public OriginService(IConfiguration configuration) : base() {
            this.Configuration = configuration;
        }

        /// <summary>
        /// constructor
        /// </summary>
        public OriginService() : base() {
            this.Configuration = new Configuration();
        }

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
            this.DataSource = this.OriginFromLayout(this.OriginsFromString());
            return this;
        }

        /// <summary>
        /// almacenar datos
        /// </summary>
        public IOriginService Save() {
            this.WriteFile();
            return this;
        }

        /// <summary>
        /// eliminar archivo de datos
        /// </summary>
        public IOriginService Delete() {
            return this;
        }

        /// <summary>
        /// agregar origen
        /// </summary>
        /// <param name="origin">interface de origen</param>
        /// <returns></returns>
        public IOriginService Add(IOrigin origin) {
            if (this.DataSource == null) {
                this.DataSource = new List<IOrigin>();
            }

            if (this.DataSource.Where(it => it.Equals(origin)).Count() == 0) {
                this.DataSource.Add(origin);
            }
            return this;
        }

        #region builder
        protected string BuildPath() {
            return Path.Combine(this.Configuration.WorkingFolder, this.Configuration.FileName);
        }

        protected List<LayoutOrigin> ReadOrigin(string content) {
            var configuration = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd/MM/yyyy" };
            return JsonConvert.DeserializeObject<List<LayoutOrigin>>(content, configuration);
        }

        protected List<LayoutOrigin> OriginsFromString() {
            if (!File.Exists(this.BuildPath())) { return null; }
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            return this.ReadOrigin(File.ReadAllText(this.BuildPath(), utf8WithoutBom));
        }

        protected void WriteFile() {
            var configuration = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd/MM/yyyy" };
            var contenido = JsonConvert.SerializeObject(OriginToLayout(this.DataSource), Newtonsoft.Json.Formatting.None, configuration);
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(this.BuildPath(), contenido, utf8WithoutBom);
        }
        #endregion
    }
}
