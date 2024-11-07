using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69B;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// importador de catalogo Articulo 69-B, listado completo
    /// </summary>
    public class Articulo69BCatalogos : AbstractXlsImporter, IImporter {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Articulo69BCatalogos(IConfiguration configuration) : base(configuration) {
            this.FileName = "Listado_Completo_69-B.csv";
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            var injectors = new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ListadoCompleto(dataSet.Tables[0]){ LastVersion = this.LastVersion}
                },
            };
            return injectors;
        }
    }
}
