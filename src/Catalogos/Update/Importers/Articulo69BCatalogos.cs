using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69B;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class Articulo69BCatalogos : AbstractXlsImporter, IImporter {
        
        public Articulo69BCatalogos(string csvFolder) : base(csvFolder) {
            this.FileName = "Listado_Completo_69-B.csv";
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            var injectors = new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ListadoCompleto(dataSet.Tables[0])
                },
            };
            return injectors;
        }
    }
}
