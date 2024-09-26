using System.Data;
using Jaeger.SAT.Catalogos.Update.Converts;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// clase abstracta para importador
    /// </summary>
    public abstract class AbstractXlsImporter : IImporter {
        /// <summary>
        /// constructor
        /// </summary>
        public AbstractXlsImporter() { }

        public AbstractXlsImporter(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        #region propiedades
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo del origen de los datos
        /// </summary>
        public string FileName { get; set; }
        #endregion

        /// <summary>
        /// verificar la existencia del archivo de origen
        /// </summary>
        public bool CheckFile() {
            return Helpers.FileService.Exists(GetFullPath());
        }

        public abstract Injectors CreateInjectors(DataSet dataSet);

        public void Import() {
            //logger.Info($"Cargando archivo {FileSource}...");
            var converter = CreateConverter();
            converter.Convert(this.GetFullPath());

            // create the injector (use a collection)
            var injector = CreateInjectors(converter.DataSet);
            injector.Validate();
            injector.Inject();
        }

        protected XlsToDataSetConverter CreateConverter() {
            return new XlsToDataSetConverter();
        }

        protected string GetFullPath() {
            return System.IO.Path.Combine(this.Configuration.WorkingFolder, FileName);
        }
    }
}
