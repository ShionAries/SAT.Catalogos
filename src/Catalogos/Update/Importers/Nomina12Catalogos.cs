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
                    new ClavesBancos(dataSet.Tables["c_Banco"]),
                    new ClavesOrigenRecurso(dataSet.Tables["c_OrigenRecurso"]),
                    new ClavesPeriodicidadPago(dataSet.Tables["c_PeriodicidadPago"]),
                    new ClavesTipoContrato(dataSet.Tables["c_TipoContrato"]),
                    new ClavesTipoDeduccion(dataSet.Tables["c_TipoDeduccion"]),
                    new ClavesTipoHoras(dataSet.Tables["c_TipoHoras"]),
                    new ClavesTipoIncapacidad(dataSet.Tables["c_TipoIncapacidad"]),
                    new ClavesTipoJornada(dataSet.Tables["c_TipoJornada"]),
                    new ClavesTipoNomina(dataSet.Tables["c_TipoNomina"]),
                    new ClavesTipoOtroPago(dataSet.Tables["c_TipoOtroPago"]),
                    new ClavesTipoPercepcion(dataSet.Tables["c_TipoPercepcion"]),
                    new ClavesTipoRegimenContratacion(dataSet.Tables["c_TipoRegimen"]),
                    new ClavesRiesgoPuesto(dataSet.Tables["c_RiesgoPuesto"]),
                }
            };
        }
    }
}
