using System;
using Jaeger.SAT.Catalogos.Database;
using Jaeger.SAT.Catalogos.Importers;

namespace Jaeger.SAT.Catalogos {
    public class UpdateDatabase {
        private string sourceFolder;
        private string destinationDatabase;

        public UpdateDatabase(string sourceCatalog, string destinationDatabase) {
            this.setSourceCatalog(sourceCatalog);
            this.setDestinationDatabase(destinationDatabase);
        }

        private void setSourceCatalog(string sourceCatalog) {
            this.sourceFolder = sourceCatalog;
        }

        private void setDestinationDatabase(string destinationDatabase) {
            this.destinationDatabase = destinationDatabase;
        }

        private string getSourceFolder() {
            return this.sourceFolder;
        }
        private string getDestinationDatabase() {
            return this.destinationDatabase;
        }
        public int Run() {
            var repository = this.createRepository();
            var importer = this.createImporter();
            //repository->pdo()->beginTransaction();
            importer.import(this.getSourceFolder(), repository, "");
            //repository->pdo()->commit();
            Console.WriteLine("Se terminó correctamente con la actualización de la base de datos");
            return 0;
        }

        public Repository createRepository() {
            return new Repository();
        }

        public SourcesImporter createImporter() {
            return new SourcesImporter();
        }
    }
}
