using System;
using System.Data;
using System.IO;
using Jaeger.SAT.Catalogos.Database;

namespace Jaeger.SAT.Catalogos {
    public abstract class AbstractCsvInjector : IInjectorInterface {
        protected DataTable _dataTable;
        protected string _sourceFile;

        public AbstractCsvInjector(string sourceFile) {
            this._sourceFile = sourceFile;
        }

        public string sourceFile() {
            return this._sourceFile;
        }

        public void validate() {
            if (!File.Exists(this._sourceFile)) { }
        }

        public int injet(Repository repository, string LoggerInterface = "") {
            var tableName = this._dataTable.TableName;
            var filename = this._sourceFile;
            var gateway = new DataTableGateway(this._dataTable, repository);
            if (this.shouldRecreateTable()) {
                Console.WriteLine($"Creando tabla {tableName}...");
                gateway.recreate();
            }
            Console.WriteLine($"Verificando encabezado de {filename}...");
            var csv = this.createCsvFileReader();
            this.checkHeaders(csv);
            Console.WriteLine($"Inyectando contenidos de {filename} a {tableName}...");

            var injected = this.injectCsvToDataTable(csv, gateway);
            Console.WriteLine($"Se inyectaron {injected} registros en {tableName}");

            return 0;
        }

        public int injectCsvToDataTable(CsvFile csv, DataTableGateway gateway) {
            var inserted = 0;
            foreach (var line in this.readLinesFromCsv(csv)) {
                //var values = gateway.dataTable().fields().transform(line);
                //this.injectValuesToDataTable(values, gateway);
                inserted = inserted + 1;
            }
            return inserted;
        }

        private void injectValuesToDataTable(object values, DataTableGateway gateway) {
            throw new NotImplementedException();
        }

        public string readLinesFromCsv(CsvFile csv) {
            return null;
        }

        public abstract void checkHeaders(CsvFile csv);

        public abstract DataTable dataTable();

        protected CsvFile createCsvFileReader() {
            return new CsvFile(this.sourceFile());
        }

        protected bool shouldRecreateTable() {
            return true;
        }
    }
}
