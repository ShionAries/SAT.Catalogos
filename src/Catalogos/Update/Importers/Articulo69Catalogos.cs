using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Articulo69;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogo del Articulo 69, No localizados
    /// </summary>
    internal class Articulo69Catalogos : AbstractXlsImporter, IImporter {

        public Articulo69Catalogos(IConfiguration configuration) : base(configuration) {
            this.FileName = "No localizados.csv";
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new NoLocalizados(dataSet.Tables[0]) { LastVersion = this.LastVersion }
                }
            };
        }
    }
}
