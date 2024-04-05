using Jaeger.SAT.Catalogos.Importers.Cfdi40;

namespace Jaeger.SAT.Catalogos.Importers {
    internal class Cfdi40Catalogs : AbstractXlsImporter , IImporterInterface {
        public Injectors createInjectors(string csvFolder) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjectorInterface>() {
                    new FormasDePago(csvFolder + "c_FormaPago")
                }
            };
        }

        public override Injectors createInjectors(string csvFolder) {
            throw new System.NotImplementedException();
        }
    }
}
