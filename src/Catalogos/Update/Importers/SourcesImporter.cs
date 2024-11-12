using System;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class SourcesImporter {
        public void Import(IConfiguration configuration) {
            var importers = new List<IImporter> {
                new Cfdi40Catalogos(configuration),
                new Nomina12Catalogos(configuration),
                new Retencion20Catalogos(configuration),
                //new CartaPorte20Catalogos(this.GetFullName(source, "CatalogosCartaPorte20.xls")),
                new CartaPorte30Catalogos(configuration),
                new CartaPorte31Catalogos(configuration),
                new Articulo69BImporter(configuration),
                new Articulo69Importer(configuration),
                new RecepcionPago20Catalogos(configuration)
            };

            foreach (var item in importers) {
                if (!item.CheckFile()) {
                    Console.WriteLine("Error");
                  //  logger.Info($"No existe el archivo{item.FileSource}");
                    return;
                }
            }

            foreach (var importer in importers) {
                importer.Import();
            }
        }
    }
}
