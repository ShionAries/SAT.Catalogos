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
                    new ClaveBancoInjector(dataSet.Tables["c_Banco"]) { LastVersion = this.LastVersion },
                    new ClaveOrigenRecursoInjector(dataSet.Tables["c_OrigenRecurso"]) { LastVersion = this.LastVersion },
                    new ClavePeriodicidadPagoInjector(dataSet.Tables["c_PeriodicidadPago"]) { LastVersion = this.LastVersion },
                    new ClaveTipoContratoInjector(dataSet.Tables["c_TipoContrato"]) { LastVersion = this.LastVersion },
                    new ClaveTipoDeduccionInjector(dataSet.Tables["c_TipoDeduccion"]) { LastVersion = this.LastVersion },
                    new ClaveTipoHorasInjector(dataSet.Tables["c_TipoHoras"]) { LastVersion = this.LastVersion },
                    new ClaveTipoIncapacidadInjector(dataSet.Tables["c_TipoIncapacidad"]) { LastVersion = this.LastVersion },
                    new ClaveTipoJornadaInjector(dataSet.Tables["c_TipoJornada"]) { LastVersion = this.LastVersion },
                    new ClaveTipoNominaInjector(dataSet.Tables["c_TipoNomina"]) { LastVersion = this.LastVersion },
                    new ClaveTipoOtroPagoInjector(dataSet.Tables["c_TipoOtroPago"]) { LastVersion = this.LastVersion },
                    new ClaveTipoPercepcionInjector(dataSet.Tables["c_TipoPercepcion"]) { LastVersion = this.LastVersion },
                    new ClaveTipoRegimenContratacionInjector(dataSet.Tables["c_TipoRegimen"]) { LastVersion = this.LastVersion },
                    new ClaveRiesgoPuestoInjector(dataSet.Tables["c_RiesgoPuesto"]) { LastVersion = this.LastVersion }
                }
            };
        }
    }
}
