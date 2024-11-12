using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Ret20;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Retencion e Informacion de Pagos
    /// </summary>
    public class Retencion20Importer : AbstractXlsImporter, IImporter {
        public Retencion20Importer() : base() {
            this.FileName = "ret_20.xls";
        }

        public Retencion20Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector> {
                    new ClaveRetencionesInjector(dataSet.Tables["c_CveRetenc"]),
                    new ClavePeriodoInjector(dataSet.Tables["c_Periodo"]),
                    new ClaveEjercicioInjector(dataSet.Tables["c_Ejercicio"]),
                    new ClaveTipoPagoRetencionInjector(dataSet.Tables["c_TipoPagoRet"]),
                    new ClaveEntidadFederativaInjector(dataSet.Tables["c_EntidadesFederativas"]),
                    new ClavePaisInjector(dataSet.Tables["c_Pais"]),
                    new ClavePeriodicidadInjector(dataSet.Tables["c_Periodicidad"]),
                    new ClaveTipoContribuyenteSujetoRetencionInjector(dataSet.Tables["c_TipoContribuyenteSujetoRetenc"]),
                    new ClaveTipoDividendoOUtilidadDistribuidaInjector(dataSet.Tables["c_TipoDividendoOUtilidadDistrib"]),
                    new ClaveTipoImpuestoInjector(dataSet.Tables["c_TipoImpuesto"])
                }
            };
        }
    }
}
