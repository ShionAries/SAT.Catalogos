using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    internal class Cfdi40Catalogs : AbstractXlsImporter, IImporter {
        public Cfdi40Catalogs(string csvFolder) : base(csvFolder) {
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjectorInterface>() {
                    new FormasDePago(dataSet.Tables["c_FormaPago"]),
                    new ClavesUnidades(dataSet.Tables["c_ClaveUnidad"]),
                }
            };
        }
    }
}
