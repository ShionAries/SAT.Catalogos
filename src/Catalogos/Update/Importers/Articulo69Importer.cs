using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogo del Articulo 69, No localizados
    /// </summary>
    internal class Articulo69Importer : AbstractXlsImporter, IImporter {
        public Articulo69Importer() : base() {
            this.FileName = "No localizados.csv";
        }

        public Articulo69Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new NoLocalizados(dataSet.Tables[0]) { LastUpdate = this.LastVersion }
                }
            };
        }
    }
}
