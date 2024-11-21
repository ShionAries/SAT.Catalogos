using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Nom12;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogos de estados Nomina
    /// </summary>
    internal class NominaEstadoImporter : AbstractXlsImporter, IImporter {
        public NominaEstadoImporter() : base() {
            this.FileName = "nominas_estados.xls";
        }

        public NominaEstadoImporter(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new EstadosInjector(dataSet.Tables["c_Estado"]) { LastUpdate = this.LastVersion },
                }
            };
        }
    }
}
