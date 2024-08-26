using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    internal class Articulo69Catalogos : AbstractXlsImporter, IImporter {

        public Articulo69Catalogos(string csvFolder) : base(csvFolder) {

        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new NoLocalizados(dataSet.Tables[0])
                }
            };
        }
    }
}
