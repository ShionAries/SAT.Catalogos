using System;
using System.Collections.Generic;


namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class SourcesImporter {
        public void Import(string source, Helpers.ILogger logger) {
            var importes = new List<IImporter> {
                //new Cfdi40Catalogs(source + @"\cfdi_40.xls"),
                //new NominaCatalogs(source + @"\catNomina.xls"),
                //new RetencionCatalogs(source + @"\ret_20.xls"),
                new CartaPorte30Catalogs(source + @"\CatalogosCartaPorte30.xls"),
                //new Articulo69BCatalogs(source + @"\Listado_Completo_69-B.csv"),
                //new Articulo69Catalogs(source + @"\No localizados.csv")
            };

            foreach (var item in importes) {
                if (!item.CheckFile()) {
                    Console.WriteLine("Error");
                    logger.Info($"No existe el archivo{item._FileSource}");
                    return;
                }
            }

            foreach (var importer in importes) {
                importer.Import(logger);
            }
        }
    }
}
