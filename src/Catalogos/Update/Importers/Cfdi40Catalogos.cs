using System.Data;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Update.Importers.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogo de CFDI version 4.0
    /// </summary>
    internal class Cfdi40Catalogos : AbstractXlsImporter, IImporter {
        public Cfdi40Catalogos(IConfiguration configuration) : base(configuration) {
            this.FileName = "cfdi_40.xls";
        }

        public Cfdi40Catalogos(IOrigin origin, IConfiguration configuration) : base(configuration) {
            this.FileName = origin.DestinationFilename;
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors() {
                Items = new System.Collections.Generic.List<IInjector>() {
                    new ClavesFormasDePago(dataSet.Tables["c_FormaPago"]) { LastVersion = this.LastVersion },
                    new ClavesMonedas(dataSet.Tables["c_Moneda"])  { LastVersion = this.LastVersion },
                    new ClavesTipoComprobante(dataSet.Tables["c_TipoDeComprobante"]) { LastVersion = this.LastVersion },
                    new ClavesExportacion(dataSet.Tables["c_Exportacion"]) { LastVersion = this.LastVersion },
                    new ClavesMetodoPago(dataSet.Tables["c_MetodoPago"]) { LastVersion = this.LastVersion },
                    new ClavesCodigosPostales(dataSet.Tables["c_CodigoPostal_Parte"]) { LastVersion = this.LastVersion },
                    new ClavesPeriodicidad(dataSet.Tables["c_Periodicidad"]) { LastVersion = this.LastVersion },
                    new ClavesMeses(dataSet.Tables["c_Meses"]) { LastVersion = this.LastVersion },
                    new ClavesTipoRelacion(dataSet.Tables["c_TipoRelacion"]) { LastVersion = this.LastVersion },
                    new ClavesRegimenesFiscales(dataSet.Tables["c_RegimenFiscal"]) { LastVersion = this.LastVersion },
                    new ClavesPais(dataSet.Tables["c_Pais"]) { LastVersion = this.LastVersion },
                    new ClavesUsoCFDI(dataSet.Tables["c_UsoCFDI"]) { LastVersion = this.LastVersion },
                    new ClavesProdServ(dataSet.Tables["c_ClaveProdServ"]) { LastVersion = this.LastVersion },
                    new ClavesUnidades(dataSet.Tables["c_ClaveUnidad"]) { LastVersion = this.LastVersion },
                    new ClavesObjetoImpuestos(dataSet.Tables["c_ObjetoImp"]) { LastVersion = this.LastVersion },
                    new ClavesImpuestos(dataSet.Tables["c_Impuesto"]) { LastVersion = this.LastVersion },
                    new ClavesTipoFactor(dataSet.Tables["c_TipoFactor"]) { LastVersion = this.LastVersion },
                    new ClavesTasaOCuota(dataSet.Tables["c_TasaOCuota"]) { LastVersion = this.LastVersion },
                    new ClavesAduanas(dataSet.Tables["c_Aduana"]) { LastVersion = this.LastVersion },
                    new ClavesNumeroPedimentoAduanal(dataSet.Tables["c_NumPedimentoAduana"]) { LastVersion = this.LastVersion },
                    new ClavesPatenteAduanal(dataSet.Tables["c_PatenteAduanal"]) { LastVersion = this.LastVersion },
                    new ClavesColonia(dataSet.Tables["c_Colonia"]) { LastVersion = this.LastVersion },
                    new ClavesEstados(dataSet.Tables["c_Estado"]) { LastVersion = this.LastVersion },
                    new ClavesLocalidad(dataSet.Tables["C_Localidad"]) { LastVersion = this.LastVersion },
                    new ClavesMunicipio(dataSet.Tables["C_Municipio"]) { LastVersion = this.LastVersion }
                }
            };
        }
    }
}
