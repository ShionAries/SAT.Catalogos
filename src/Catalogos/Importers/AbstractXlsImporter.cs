using System;
using System.Data;
using Jaeger.SAT.Catalogos.Converts;

namespace Jaeger.SAT.Catalogos.Importers {
    public abstract class AbstractXlsImporter : IImporter {
        protected string _FileSource;

        public AbstractXlsImporter(string csvFolder) {
            this._FileSource = csvFolder;
        }

        public bool CheckFile() {
            return System.IO.File.Exists(this._FileSource);
        }

        public abstract Injectors CreateInjectors(DataSet dataSet);

        public void Import() {
            
            Console.WriteLine($"Convirtiendo a archivo {_FileSource}...");
            var converter = this.CreateConverter();
            converter.Convert(_FileSource);

            // create the injector (use a collection)
            var injector = this.CreateInjectors(converter.DataSet);
            injector.Validate();

            injector.Inject("");
        }

        public XlsToDataSetConverter CreateConverter() {
            return new XlsToDataSetConverter();
        }
    }
}
