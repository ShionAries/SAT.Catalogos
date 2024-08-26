using System.Data;
using Jaeger.SAT.Catalogos.Update.Converts;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public abstract class AbstractXlsImporter : IImporter {
        /// <summary>
        /// constructor
        /// </summary>
        public AbstractXlsImporter(string csvFolder) {
            FileSource = csvFolder;
        }

        public string FileSource { get; set; }

        public string DirectorySource { get; set; }

        public bool CheckFile() {
            return Helpers.FileService.Exists(FileSource);
        }

        public abstract Injectors CreateInjectors(DataSet dataSet);

        public void Import(Helpers.ILogger logger) {
            logger.Info($"Cargando archivo {FileSource}...");
            var converter = CreateConverter();
            converter.Convert(FileSource);

            // create the injector (use a collection)
            var injector = CreateInjectors(converter.DataSet);
            injector.Validate();
            injector.Inject(logger);
        }

        public XlsToDataSetConverter CreateConverter() {
            return new XlsToDataSetConverter();
        }
    }
}
