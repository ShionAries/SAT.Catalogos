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
                    new RetencionesInjector(dataSet.Tables["c_CveRetenc"]),
                    new PeriodoInjector(dataSet.Tables["c_Periodo"]),
                    new EjercicioInjector(dataSet.Tables["c_Ejercicio"]),
                    new TipoPagoRetencionInjector(dataSet.Tables["c_TipoPagoRet"]),
                    new EntidadFederativaInjector(dataSet.Tables["c_EntidadesFederativas"]),
                    new PaisInjector(dataSet.Tables["c_Pais"]),
                    new PeriodicidadInjector(dataSet.Tables["c_Periodicidad"]),
                    new TipoContribuyenteSujetoRetencionInjector(dataSet.Tables["c_TipoContribuyenteSujetoRetenc"]),
                    new TipoDividendoOUtilidadDistribuidaInjector(dataSet.Tables["c_TipoDividendoOUtilidadDistrib"]),
                    new TipoImpuestoInjector(dataSet.Tables["c_TipoImpuesto"])
                }
            };
        }
    }
}
