using System.Data;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class StandarImporter : AbstractImporter, IImporter {

        public StandarImporter() : base() {
            this.FileName = "captchas.xml";
        }

        public StandarImporter(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base() {
            this.Origin = origin;
            this.Configuration = configuration;
            this.FileName = "captchas.xml";
        }

        #region propiedades
        /// <summary>
        /// obtener o establecer objeto de configuracion
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// obtener o establecer objeto de origen
        /// </summary>
        public Scraping.Interfaces.IOrigin Origin { get; set; }
        #endregion

        /// <summary>
        /// obtener si el archivo existe
        /// </summary>
        public bool CheckFile() {
            return Helpers.FileService.Exists(GetFullPath());
        }

        /// <summary>
        /// crear inyectores a partir del dataset
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public Injectors CreateInjectors(DataSet dataSet) {
            var injectors = new Injectors();
            return injectors;
        }

        /// <summary>
        /// operacion de importacion
        /// </summary>
        public void Import() {
            if (this.CheckFile()) {

            }
        }

        protected string GetFullPath() {
            return System.IO.Path.Combine(this.Configuration.WorkingFolder, FileName);
        }
    }
}
