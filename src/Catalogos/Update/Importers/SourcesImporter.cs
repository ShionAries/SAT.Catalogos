using System;
using System.Collections.Generic;


namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class SourcesImporter {
        public void Import(string source, Helpers.ILogger logger) {
            var importes = new List<IImporter> {
                //new Cfdi40Catalogos(source + @"\cfdi_40.xls"),
                //new NominaCatalogos(source + @"\catNomina.xls"),
                //new RetencionCatalogos(source + @"\ret_20.xls"),
                //new CartaPorte20Catalogos(source + @"\CatalogosCartaPorte20.xls"),
                //new CartaPorte30Catalogos(source + @"\CatalogosCartaPorte30.xls"),
                //new CartaPorte31Catalogos(source + @"\CatalogosCartaPorte31.xls"),
                //new Articulo69BCatalogos(source + @"\Listado_Completo_69-B.csv"),
                //new Articulo69Catalogos(source + @"\No localizados.csv"),
                new RecepcionPago20Catalogos(source + @"\catPagos.xls")
            };

            foreach (var item in importes) {
                if (!item.CheckFile()) {
                    Console.WriteLine("Error");
                    logger.Info($"No existe el archivo{item.FileSource}");
                    return;
                }
            }

            foreach (var importer in importes) {
                importer.Import(logger);
            }
        }
    }
}
