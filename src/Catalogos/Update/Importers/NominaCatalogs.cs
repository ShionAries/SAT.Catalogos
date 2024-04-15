using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Nomina;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    internal class NominaCatalogs : AbstractXlsImporter, IImporter {
        public NominaCatalogs(string csvFolder) : base(csvFolder) {
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ClavesBancos(dataSet.Tables["c_Banco"])
                }
            };
        }
    }
}
