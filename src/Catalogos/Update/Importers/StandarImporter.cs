using System.Data;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class StandarImporter : IImporter {

        public StandarImporter() : base() {
            this.FileName = "captchas.xml";
        }

        public StandarImporter(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base() {
            this.Origin = origin;
            this.Configuration = configuration;
            this.FileName = "captchas.xml";
        }

        #region propiedades
        public System.DateTime? LastVersion { get; set; }

        public IConfiguration Configuration { get; set; }

        public Scraping.Interfaces.IOrigin Origin { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo del origen de los datos
        /// </summary>
        public string FileName { get; set; }
        #endregion

        public bool CheckFile() {
            return Helpers.FileService.Exists(GetFullPath());
        }

        public Injectors CreateInjectors(DataSet dataSet) {
            var injectors = new Injectors();
            return injectors;
        }

        public void Import() {
            if (this.CheckFile()) {

            }
        }

        protected string GetFullPath() {
            return System.IO.Path.Combine(this.Configuration.WorkingFolder, FileName);
        }
    }
}
