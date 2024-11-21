using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69B;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// importador de catalogo Articulo 69-B, listado completo
    /// </summary>
    public class Articulo69BImporter : AbstractXlsImporter, IImporter {
        public Articulo69BImporter() : base() {
            this.FileName = "Listado_Completo_69-B.csv";
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Articulo69BImporter(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            var injectors = new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ListadoCompletoInjector(dataSet.Tables[0]){ LastUpdate = this.LastVersion }
                }
            };
            return injectors;
        }
    }
}
