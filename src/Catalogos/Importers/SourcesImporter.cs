using System;
using System.Collections.Generic;
using System.IO;
using Jaeger.SAT.Catalogos.Database;

namespace Jaeger.SAT.Catalogos.Importers {
    public class SourcesImporter : IImporterInterface {
        public void import(string source, Repository repository, string logger) {
            var importes = new Dictionary<string, object> {
                { source, new Cfdi40Catalogs() }
            };

            foreach (var item in importes) {
                if (!File.Exists(item.Key)) {
                    Console.WriteLine("Error");
                    return;
                }
            }

            foreach (var item in importes) {
                var importer = item.Value as IImporterInterface;
                importer.import(source, repository, logger);
            }
        }
    }
}
