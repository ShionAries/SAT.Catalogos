using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogo de CFDI version 4.0
    /// </summary>
    internal class Cfdi40Importer : AbstractXlsImporter, IImporter {
        public Cfdi40Importer() : base() {
            this.FileName = "cfdi_40.xls";
        }

        public Cfdi40Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector>() {
                    new ClaveFormaDePagoInjector(dataSet.Tables["c_FormaPago"]) { LastVersion = this.LastVersion },
                    new ClaveMonedaInjector(dataSet.Tables["c_Moneda"])  { LastVersion = this.LastVersion },
                    new ClaveTipoComprobanteInjector(dataSet.Tables["c_TipoDeComprobante"]) { LastVersion = this.LastVersion },
                    new ClaveExportacionInjector(dataSet.Tables["c_Exportacion"]) { LastVersion = this.LastVersion },
                    new ClaveMetodoPagoInjector(dataSet.Tables["c_MetodoPago"]) { LastVersion = this.LastVersion },
                    new ClaveCodigoPostalInjector(dataSet.Tables["c_CodigoPostal_Parte"]) { LastVersion = this.LastVersion },
                    new ClavePeriodicidadInjector(dataSet.Tables["c_Periodicidad"]) { LastVersion = this.LastVersion },
                    new ClaveMesesInjector(dataSet.Tables["c_Meses"]) { LastVersion = this.LastVersion },
                    new ClaveTipoRelacionInjector(dataSet.Tables["c_TipoRelacion"]) { LastVersion = this.LastVersion },
                    new ClaveRegimenesFiscalesInjector(dataSet.Tables["c_RegimenFiscal"]) { LastVersion = this.LastVersion },
                    new ClavePaisInjector(dataSet.Tables["c_Pais"]) { LastVersion = this.LastVersion },
                    new ClaveUsoCFDIInjector(dataSet.Tables["c_UsoCFDI"]) { LastVersion = this.LastVersion },
                    new ClaveProdServInjector(dataSet.Tables["c_ClaveProdServ"]) { LastVersion = this.LastVersion },
                    new ClaveUnidadInjector(dataSet.Tables["c_ClaveUnidad"]) { LastVersion = this.LastVersion },
                    new ClaveObjetoImpuestoInjector(dataSet.Tables["c_ObjetoImp"]) { LastVersion = this.LastVersion },
                    new ClaveImpuestoInjector(dataSet.Tables["c_Impuesto"]) { LastVersion = this.LastVersion },
                    new ClaveTipoFactorInjector(dataSet.Tables["c_TipoFactor"]) { LastVersion = this.LastVersion },
                    new ClaveTasaOCuotaInjector(dataSet.Tables["c_TasaOCuota"]) { LastVersion = this.LastVersion },
                    new ClaveAduanaInjector(dataSet.Tables["c_Aduana"]) { LastVersion = this.LastVersion },
                    new ClaveNumeroPedimentoAduanalInjector(dataSet.Tables["c_NumPedimentoAduana"]) { LastVersion = this.LastVersion },
                    new ClavePatenteAduanalInjector(dataSet.Tables["c_PatenteAduanal"]) { LastVersion = this.LastVersion },
                    new ClaveColoniaInjector(dataSet.Tables["c_Colonia"]) { LastVersion = this.LastVersion },
                    new ClaveEstadosInjector(dataSet.Tables["c_Estado"]) { LastVersion = this.LastVersion },
                    new ClaveLocalidadInjector(dataSet.Tables["C_Localidad"]) { LastVersion = this.LastVersion },
                    new ClaveMunicipioInjector(dataSet.Tables["C_Municipio"]) { LastVersion = this.LastVersion }
                }
            };
        }
    }
}
