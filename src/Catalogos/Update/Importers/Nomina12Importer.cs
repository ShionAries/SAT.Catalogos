using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Nom12;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogos de Nomina
    /// </summary>
    internal class Nomina12Importer : AbstractXlsImporter, IImporter {
        public Nomina12Importer() : base() {
            this.FileName = "catNomina.xls";
        }

        public Nomina12Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new BancoInjector(dataSet.Tables["c_Banco"]) { LastUpdate = this.LastVersion },
                    new OrigenRecursoInjector(dataSet.Tables["c_OrigenRecurso"]) { LastUpdate = this.LastVersion },
                    new PeriodicidadPagoInjector(dataSet.Tables["c_PeriodicidadPago"]) { LastUpdate = this.LastVersion },
                    new TipoContratoInjector(dataSet.Tables["c_TipoContrato"]) { LastUpdate = this.LastVersion },
                    new TipoDeduccionInjector(dataSet.Tables["c_TipoDeduccion"]) { LastUpdate = this.LastVersion },
                    new TipoHorasInjector(dataSet.Tables["c_TipoHoras"]) { LastUpdate = this.LastVersion },
                    new TipoIncapacidadInjector(dataSet.Tables["c_TipoIncapacidad"]) { LastUpdate = this.LastVersion },
                    new TipoJornadaInjector(dataSet.Tables["c_TipoJornada"]) { LastUpdate = this.LastVersion },
                    new TipoNominaInjector(dataSet.Tables["c_TipoNomina"]) { LastUpdate = this.LastVersion },
                    new TipoOtroPagoInjector(dataSet.Tables["c_TipoOtroPago"]) { LastUpdate = this.LastVersion },
                    new TipoPercepcionInjector(dataSet.Tables["c_TipoPercepcion"]) { LastUpdate = this.LastVersion },
                    new TipoRegimenContratacionInjector(dataSet.Tables["c_TipoRegimen"]) { LastUpdate = this.LastVersion },
                    new RiesgoPuestoInjector(dataSet.Tables["c_RiesgoPuesto"]) { LastUpdate = this.LastVersion }
                }
            };
        }
    }
}
