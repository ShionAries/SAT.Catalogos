using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Retenciones;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class RetencionCatalogs : AbstractXlsImporter, IImporter {
        public RetencionCatalogs(string csvFolder) : base(csvFolder) {
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ClavesRetenciones(dataSet.Tables["c_CveRetenc"]),
                    new ClavesPeriodo(dataSet.Tables["c_Periodo"]),
                    new ClavesEjercicio(dataSet.Tables["c_Ejercicio"]),
                    new ClavesTipoPagoRetencion(dataSet.Tables["c_TipoPagoRet"]),
                    new ClavesEntidadFederativa(dataSet.Tables["c_EntidadesFederativas"]),
                    new ClavesPais(dataSet.Tables["c_Pais"]),
                    new ClavesPeriodicidad(dataSet.Tables["c_Periodicidad"]),
                    new ClavesTipoContribuyenteSujetoRetencion(dataSet.Tables["c_TipoContribuyenteSujetoRetenc"]),
                    new ClavesTipoDividendoOUtilidadDistribuida(dataSet.Tables["c_TipoDividendoOUtilidadDistrib"]),
                    new ClavesTipoImpuesto(dataSet.Tables["c_TipoImpuesto"])
                }
            };
        }
    }
}
