using Jaeger.SAT.Catalogos.Database;
using System;

namespace Jaeger.SAT.Catalogos.Importers {
    public abstract class AbstractXlsImporter : IImporterInterface {
        protected string csvFolder;

        public abstract Injectors createInjectors(string csvFolder);

        public void import(string source, Repository repository, string logger) {
            // csvFolder = tempdir();
            var converter = this.createConverter();
            converter.
        }

        protected void removeCsvFolder(string cvsFolder) {

        }

        public XlsToCsvFolderConverter createConverter() {
            return new XlsToCsvFolderConverter();
        }
    }
}
