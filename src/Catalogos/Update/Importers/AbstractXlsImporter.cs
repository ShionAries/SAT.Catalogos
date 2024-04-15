using System.Data;
using Jaeger.SAT.Catalogos.Update.Converts;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public abstract class AbstractXlsImporter : IImporter {

        public AbstractXlsImporter(string csvFolder) {
            _FileSource = csvFolder;
        }
        public string _FileSource {  get; set; }

        public bool CheckFile() {
            return System.IO.File.Exists(_FileSource);
        }

        public abstract Injectors CreateInjectors(DataSet dataSet);

        public void Import(Helpers.ILogger logger) {

            logger.Info($"Convirtiendo a archivo {_FileSource}...");
            var converter = CreateConverter();
            converter.Convert(_FileSource);

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
