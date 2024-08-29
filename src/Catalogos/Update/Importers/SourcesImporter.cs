using System;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class SourcesImporter {
        public void Import(string source, Helpers.ILogger logger) {
            var importers = new List<IImporter> {
                new Cfdi40Catalogos(this.GetFullName(source, "cfdi_40.xls")),
                new Nomina12Catalogos(this.GetFullName(source, "catNomina.xls")),
                new Retencion20Catalogos(this.GetFullName(source, "ret_20.xls")),
                //new CartaPorte20Catalogos(this.GetFullName(source, "CatalogosCartaPorte20.xls")),
                new CartaPorte30Catalogos(this.GetFullName(source, "CatalogosCartaPorte30.xls")),
                new CartaPorte31Catalogos(this.GetFullName(source, "CatalogosCartaPorte31.xls")),
                new Articulo69BCatalogos(this.GetFullName(source, "Listado_Completo_69-B.csv")),
                new Articulo69Catalogos(this.GetFullName(source, "No localizados.csv")),
                new RecepcionPago20Catalogos(this.GetFullName(source, "catPagos.xls")) { DirectorySource = source }
            };

            foreach (var item in importers) {
                if (!item.CheckFile()) {
                    Console.WriteLine("Error");
                    logger.Info($"No existe el archivo{item.FileSource}");
                    return;
                }
            }

            foreach (var importer in importers) {
                importer.Import(logger);
            }
        }

        protected internal string GetFullName(string sourceFolder, string fileName) {
            return System.IO.Path.Combine(sourceFolder, fileName);
        }
    }
}
