using System.Data;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Update.Importers.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers {
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
                    new ClavesFormasDePago(dataSet.Tables["c_FormaPago"]),
                    new ClavesMonedas(dataSet.Tables["c_Moneda"]),
                    new ClavesTipoComprobante(dataSet.Tables["c_TipoDeComprobante"]),
                    new ClavesExportacion(dataSet.Tables["c_Exportacion"]),
                    new ClavesMetodoPago(dataSet.Tables["c_MetodoPago"]),
                    new ClavesCodigosPostales(dataSet.Tables["c_CodigoPostal_Parte"]),
                    new ClavesPeriodicidad(dataSet.Tables["c_Periodicidad"]),
                    new ClavesMeses(dataSet.Tables["c_Meses"]),
                    new ClavesTipoRelacion(dataSet.Tables["c_TipoRelacion"]),
                    new ClavesRegimenesFiscales(dataSet.Tables["c_RegimenFiscal"]),
                    new ClavesPais(dataSet.Tables["c_Pais"]),
                    new ClavesUsoCFDI(dataSet.Tables["c_UsoCFDI"]),
                    new ClavesProdServ(dataSet.Tables["c_ClaveProdServ"]),
                    new ClavesUnidades(dataSet.Tables["c_ClaveUnidad"]),
                    new ClavesObjetoImpuestos(dataSet.Tables["c_ObjetoImp"]),
                    new ClavesImpuestos(dataSet.Tables["c_Impuesto"]),
                    new ClavesTipoFactor(dataSet.Tables["c_TipoFactor"]),
                    new ClavesTasaOCuota(dataSet.Tables["c_TasaOCuota"]),
                    new ClavesAduanas(dataSet.Tables["c_Aduana"]),
                    new ClavesNumeroPedimentoAduanal(dataSet.Tables["c_NumPedimentoAduana"]),
                    new ClavesPatenteAduanal(dataSet.Tables["c_PatenteAduanal"]),
                    new ClavesColonia(dataSet.Tables["c_Colonia"]),
                    new ClavesEstados(dataSet.Tables["c_Estado"]),
                    new ClavesLocalidad(dataSet.Tables["C_Localidad"]),
                    new ClavesMunicipio(dataSet.Tables["C_Municipio"]),
                }
            };
        }
    }
}
