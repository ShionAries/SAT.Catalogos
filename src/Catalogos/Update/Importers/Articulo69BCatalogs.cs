using System.Data;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69B;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    internal class Articulo69BCatalogs : AbstractXlsImporter, IImporter {
        
        public Articulo69BCatalogs(string csvFolder) : base(csvFolder) {
        
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ListadoCompleto(dataSet.Tables[0])
                }
            };
        }
    }
}
