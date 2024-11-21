using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Cfdi33;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogo de CFDI version 3.3
    /// </summary>
    internal class Cfdi33Importer : AbstractXlsImporter, IImporter {
        public Cfdi33Importer() : base() {
            this.FileName = "cfdi_33.xls";
        }

        public Cfdi33Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector>() {
                    new FormaDePagoInjector(dataSet.Tables["c_FormaPago"]) { LastUpdate = this.LastVersion },
                    new MonedaInjector(dataSet.Tables["c_Moneda"])  { LastUpdate = this.LastVersion },
                    new TipoComprobanteInjector(dataSet.Tables["c_TipoDeComprobante"]) { LastUpdate = this.LastVersion },
                    new MetodoPagoInjector(dataSet.Tables["c_MetodoPago"]) { LastUpdate = this.LastVersion },
                    new CodigoPostalInjector(dataSet.Tables["c_CodigoPostal_Parte"]) { LastUpdate = this.LastVersion },
                    new TipoRelacionInjector(dataSet.Tables["c_TipoRelacion"]) { LastUpdate = this.LastVersion },
                    new RegimenesFiscalesInjector(dataSet.Tables["c_RegimenFiscal"]) { LastUpdate = this.LastVersion },
                    new PaisInjector(dataSet.Tables["c_Pais"]) { LastUpdate = this.LastVersion },
                    new ClaveUsoCFDIInjector(dataSet.Tables["c_UsoCFDI"]) { LastUpdate = this.LastVersion },
                    new ProdServInjector(dataSet.Tables["c_ClaveProdServ"]) { LastUpdate = this.LastVersion },
                    new UnidadInjector(dataSet.Tables["c_ClaveUnidad"]) { LastUpdate = this.LastVersion },
                    new ImpuestoInjector(dataSet.Tables["c_Impuesto"]) { LastUpdate = this.LastVersion },
                    new TipoFactorInjector(dataSet.Tables["c_TipoFactor"]) { LastUpdate = this.LastVersion },
                    new TasaOCuotaInjector(dataSet.Tables["c_TasaOCuota"]) { LastUpdate = this.LastVersion },
                    new AduanaInjector(dataSet.Tables["c_Aduana"]) { LastUpdate = this.LastVersion },
                    new NumeroPedimentoAduanalInjector(dataSet.Tables["c_NumPedimentoAduana"]) { LastUpdate = this.LastVersion },
                    new PatenteAduanalInjector(dataSet.Tables["c_PatenteAduanal"]) { LastUpdate = this.LastVersion }
                }
            };
        }
    }
}
