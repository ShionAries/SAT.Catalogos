using System.Collections.Generic;
using System.IO;
using System.Text;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// clase para servicio de origenes
    /// </summary>
    public class OriginService : OriginsTranslator {

        /// <summary>
        /// constructor
        /// </summary>
        public OriginService(Configuration configuration) {
            this.Configuration = configuration;
        }

        /// <summary>
        /// constructor
        /// </summary>
        public OriginService() {
            this.Configuration = new Configuration();
        }

        public Configuration Configuration { get; set; }

        /// <summary>
        /// obtener o establecer lista de origines de datos
        /// </summary>
        public List<IOrigin> DataSource { get; set; }

        public OriginService GetAll() {
            this.DataSource = this.OriginFromLayout(this.OriginsFromString());
            return this;
        }

        /// <summary>
        /// almacenar datos
        /// </summary>
        public OriginService SaveChanges() {
            this.WriteFile();
            return this;
        }

        /// <summary>
        /// eliminar archivo de datos
        /// </summary>
        public OriginService Delete() {
            return this;
        }

        /// <summary>
        /// agregar origen
        /// </summary>
        /// <param name="origin">interface de origen</param>
        /// <returns></returns>
        public OriginService Add(IOrigin origin) {
            if (this.DataSource == null) {
                this.DataSource = new List<IOrigin>();
            }
            this.DataSource.Add(origin);
            return this;
        }

        #region builder
        protected string BuildPath() {
            return Path.Combine(this.Configuration.WorkingFolder, this.Configuration.FileName);
        }

        protected List<LayoutOrigin> ReadOrigin(string content) {
            return XmlSerializerService.DeserializeObject<List<LayoutOrigin>>(content);
        }

        protected List<LayoutOrigin> OriginsFromString() {
            if (!File.Exists(this.BuildPath())) { return null; }
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            return this.ReadOrigin(File.ReadAllText(this.BuildPath(), utf8WithoutBom));
        }

        protected void WriteFile() {
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(this.BuildPath(), this.OriginsToString(this.DataSource), utf8WithoutBom);
        }

        protected string OriginsToString(List<IOrigin> origins) {
            return XmlSerializerService.SerializeObject(this.OriginToLayout(origins));
        }
        #endregion
    }
}
