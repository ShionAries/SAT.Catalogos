using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Nom12;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogos de Nomina
    /// </summary>
    internal class Nomina12Catalogos : AbstractXlsImporter, IImporter {
        public Nomina12Catalogos(IConfiguration configuration) : base(configuration) {
            this.FileName = "catNomina.xls";
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ClavesBancos(dataSet.Tables["c_Banco"]) { LastVersion = this.LastVersion },
                    new ClavesOrigenRecurso(dataSet.Tables["c_OrigenRecurso"]) { LastVersion = this.LastVersion },
                    new ClavesPeriodicidadPago(dataSet.Tables["c_PeriodicidadPago"]) { LastVersion = this.LastVersion },
                    new ClavesTipoContrato(dataSet.Tables["c_TipoContrato"]) { LastVersion = this.LastVersion },
                    new ClavesTipoDeduccion(dataSet.Tables["c_TipoDeduccion"]) { LastVersion = this.LastVersion },
                    new ClavesTipoHoras(dataSet.Tables["c_TipoHoras"]) { LastVersion = this.LastVersion },
                    new ClavesTipoIncapacidad(dataSet.Tables["c_TipoIncapacidad"]) { LastVersion = this.LastVersion },
                    new ClavesTipoJornada(dataSet.Tables["c_TipoJornada"]) { LastVersion = this.LastVersion },
                    new ClavesTipoNomina(dataSet.Tables["c_TipoNomina"]) { LastVersion = this.LastVersion },
                    new ClavesTipoOtroPago(dataSet.Tables["c_TipoOtroPago"]) { LastVersion = this.LastVersion },
                    new ClavesTipoPercepcion(dataSet.Tables["c_TipoPercepcion"]) { LastVersion = this.LastVersion },
                    new ClavesTipoRegimenContratacion(dataSet.Tables["c_TipoRegimen"]) { LastVersion = this.LastVersion },
                    new ClavesRiesgoPuesto(dataSet.Tables["c_RiesgoPuesto"]) { LastVersion = this.LastVersion }
                }
            };
        }
    }
}
