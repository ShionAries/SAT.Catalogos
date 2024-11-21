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
                    new FormaDePagoInjector(dataSet.Tables["c_FormaPago"]) { LastUpdate = this.LastVersion },
                    new MonedaInjector(dataSet.Tables["c_Moneda"])  { LastUpdate = this.LastVersion },
                    new TipoComprobanteInjector(dataSet.Tables["c_TipoDeComprobante"]) { LastUpdate = this.LastVersion },
                    new ExportacionInjector(dataSet.Tables["c_Exportacion"]) { LastUpdate = this.LastVersion },
                    new MetodoPagoInjector(dataSet.Tables["c_MetodoPago"]) { LastUpdate = this.LastVersion },
                    new CodigoPostalInjector(dataSet.Tables["c_CodigoPostal_Parte"]) { LastUpdate = this.LastVersion },
                    new PeriodicidadInjector(dataSet.Tables["c_Periodicidad"]) { LastUpdate = this.LastVersion },
                    new MesesInjector(dataSet.Tables["c_Meses"]) { LastUpdate = this.LastVersion },
                    new TipoRelacionInjector(dataSet.Tables["c_TipoRelacion"]) { LastUpdate = this.LastVersion },
                    new RegimenesFiscalesInjector(dataSet.Tables["c_RegimenFiscal"]) { LastUpdate = this.LastVersion },
                    new PaisInjector(dataSet.Tables["c_Pais"]) { LastUpdate = this.LastVersion },
                    new UsoCFDIInjector(dataSet.Tables["c_UsoCFDI"]) { LastUpdate = this.LastVersion },
                    new ProdServInjector(dataSet.Tables["c_ClaveProdServ"]) { LastUpdate = this.LastVersion },
                    new UnidadInjector(dataSet.Tables["c_ClaveUnidad"]) { LastUpdate = this.LastVersion },
                    new ObjetoImpuestoInjector(dataSet.Tables["c_ObjetoImp"]) { LastUpdate = this.LastVersion },
                    new ImpuestoInjector(dataSet.Tables["c_Impuesto"]) { LastUpdate = this.LastVersion },
                    new TipoFactorInjector(dataSet.Tables["c_TipoFactor"]) { LastUpdate = this.LastVersion },
                    new TasaOCuotaInjector(dataSet.Tables["c_TasaOCuota"]) { LastUpdate = this.LastVersion },
                    new AduanaInjector(dataSet.Tables["c_Aduana"]) { LastUpdate = this.LastVersion },
                    new NumeroPedimentoAduanalInjector(dataSet.Tables["c_NumPedimentoAduana"]) { LastUpdate = this.LastVersion },
                    new PatenteAduanalInjector(dataSet.Tables["c_PatenteAduanal"]) { LastUpdate = this.LastVersion },
                    new ColoniaInjector(dataSet.Tables["c_Colonia"]) { LastUpdate = this.LastVersion },
                    new EstadosInjector(dataSet.Tables["c_Estado"]) { LastUpdate = this.LastVersion },
                    new LocalidadInjector(dataSet.Tables["C_Localidad"]) { LastUpdate = this.LastVersion },
                    new MunicipioInjector(dataSet.Tables["C_Municipio"]) { LastUpdate = this.LastVersion }
                }
            };
        }
    }
}
