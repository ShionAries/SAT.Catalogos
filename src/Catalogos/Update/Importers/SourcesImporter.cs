using System;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class SourcesImporter {
        public void Import(string source, Helpers.ILogger logger) {
            var importes = new List<IImporter> {
                new Cfdi40Catalogs(source + @"\cfdi_40.xls"),
                new Articulo69BCatalogs(source + @"\Listado_Completo_69-B.csv"),
                new Articulo69Catalogs(source + @"\No localizados.csv")
            };

            foreach (var item in importes) {
                if (!item.CheckFile()) {
                    Console.WriteLine("Error");
                    return;
                }
            }

            foreach (var importer in importes) {
                importer.Import(logger);
            }
        }
    }
}
