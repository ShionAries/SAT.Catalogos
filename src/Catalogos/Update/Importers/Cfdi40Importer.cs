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
                    new FormaDePagoInjector(dataSet.Tables["c_FormaPago"]) { LastVersion = this.LastVersion },
                    new MonedaInjector(dataSet.Tables["c_Moneda"])  { LastVersion = this.LastVersion },
                    new TipoComprobanteInjector(dataSet.Tables["c_TipoDeComprobante"]) { LastVersion = this.LastVersion },
                    new ExportacionInjector(dataSet.Tables["c_Exportacion"]) { LastVersion = this.LastVersion },
                    new MetodoPagoInjector(dataSet.Tables["c_MetodoPago"]) { LastVersion = this.LastVersion },
                    new CodigoPostalInjector(dataSet.Tables["c_CodigoPostal_Parte"]) { LastVersion = this.LastVersion },
                    new PeriodicidadInjector(dataSet.Tables["c_Periodicidad"]) { LastVersion = this.LastVersion },
                    new MesesInjector(dataSet.Tables["c_Meses"]) { LastVersion = this.LastVersion },
                    new TipoRelacionInjector(dataSet.Tables["c_TipoRelacion"]) { LastVersion = this.LastVersion },
                    new RegimenesFiscalesInjector(dataSet.Tables["c_RegimenFiscal"]) { LastVersion = this.LastVersion },
                    new PaisInjector(dataSet.Tables["c_Pais"]) { LastVersion = this.LastVersion },
                    new UsoCFDIInjector(dataSet.Tables["c_UsoCFDI"]) { LastVersion = this.LastVersion },
                    new ProdServInjector(dataSet.Tables["c_ClaveProdServ"]) { LastVersion = this.LastVersion },
                    new UnidadInjector(dataSet.Tables["c_ClaveUnidad"]) { LastVersion = this.LastVersion },
                    new ObjetoImpuestoInjector(dataSet.Tables["c_ObjetoImp"]) { LastVersion = this.LastVersion },
                    new ImpuestoInjector(dataSet.Tables["c_Impuesto"]) { LastVersion = this.LastVersion },
                    new TipoFactorInjector(dataSet.Tables["c_TipoFactor"]) { LastVersion = this.LastVersion },
                    new TasaOCuotaInjector(dataSet.Tables["c_TasaOCuota"]) { LastVersion = this.LastVersion },
                    new AduanaInjector(dataSet.Tables["c_Aduana"]) { LastVersion = this.LastVersion },
                    new NumeroPedimentoAduanalInjector(dataSet.Tables["c_NumPedimentoAduana"]) { LastVersion = this.LastVersion },
                    new PatenteAduanalInjector(dataSet.Tables["c_PatenteAduanal"]) { LastVersion = this.LastVersion },
                    new ColoniaInjector(dataSet.Tables["c_Colonia"]) { LastVersion = this.LastVersion },
                    new EstadosInjector(dataSet.Tables["c_Estado"]) { LastVersion = this.LastVersion },
                    new LocalidadInjector(dataSet.Tables["C_Localidad"]) { LastVersion = this.LastVersion },
                    new MunicipioInjector(dataSet.Tables["C_Municipio"]) { LastVersion = this.LastVersion }
                }
            };
        }
    }
}
