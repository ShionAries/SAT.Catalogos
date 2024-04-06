using System;
using Jaeger.SAT.Catalogos.Converts;
using Jaeger.SAT.Catalogos.Database;

namespace Jaeger.SAT.Catalogos.Importers {
    public abstract class AbstractXlsImporter : IImporterInterface {
        protected string csvFolder;

        public abstract Injectors createInjectors(string csvFolder);

        public void import(string source, Repository repository, string logger) {
            // csvFolder = tempdir();
            Console.WriteLine($"Convirtiendo a archivos CSV de {source} a {csvFolder}...");
            var converter = this.createConverter();
            converter.convert(source, csvFolder);

            // create the injector (use a collection)
            var injector = this.createInjectors(source);
            injector.validate();

            injector.inject(repository, logger);
        }

        protected void removeCsvFolder(string cvsFolder) {

        }

        public XlsToCsvFolderConverter createConverter() {
            return new XlsToCsvFolderConverter();
        }
    }
}
