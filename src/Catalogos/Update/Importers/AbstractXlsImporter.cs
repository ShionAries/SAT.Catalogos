using System;
using System.Data;
using Jaeger.SAT.Catalogos.Update;
using Jaeger.SAT.Catalogos.Update.Converts;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public abstract class AbstractXlsImporter : IImporter {
        protected string _FileSource;

        public AbstractXlsImporter(string csvFolder) {
            _FileSource = csvFolder;
        }

        public bool CheckFile() {
            return System.IO.File.Exists(_FileSource);
        }

        public abstract Injectors CreateInjectors(DataSet dataSet);

        public void Import(Helpers.ILoggerInterface logger) {

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
