using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// origenes de datos
    /// </summary>
    public class DumpOrigins {
        public static string common = "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/documentos";
        /// <summary>
        /// constructor
        /// </summary>
        public DumpOrigins() {
            this.Origins = this.Default();
        }

        /// <summary>
        /// obtener o establecer lista de origenes de datos
        /// </summary>
        public List<IOrigin> Origins { get; set; }

        protected List<IOrigin> Default() {
            return new List<IOrigin>() {
                new ScrapingOrigin("CFDI 4.0", "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm", "cfdi_40.xls", "Catálogos CFDI Versión 4.0", importer: typeof(Update.Importers.Cfdi40Importer)) { AllowUpdate = true },
                new ConstantOrigin("Nóminas 1.2", $"{common}/catNomina.xls", importer: typeof(Update.Importers.Nomina12Importer)){ AllowUpdate = true },
                new ConstantOrigin("Nóminas - Estados", $"{common}/C_Estado.xls", null, "nominas_estados.xls", importer: typeof(Update.Importers.NominaEstadoImporter)){ AllowUpdate = true },
                new ConstantOrigin("REP", $"{common}/catPagos.xls", importer: typeof(Update.Importers.RecepcionPago20Importer)) { AllowUpdate = true },
                new ScrapingOrigin("RET 2.0", "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/CFDI_retenciones.htm", "ret_20.xls", "Catálogos", importer: typeof(Update.Importers.Retencion20Importer)){ AllowUpdate = true },
                //new ConstantOrigin("CCP 2.0 - Carta Porte 2.0", $"{common}/CatalogosCartaPorte20.xls", importer : typeof(Update.Importers.CartaPorte20Importer)),
                new ConstantOrigin("CCP 3.0 - Carta Porte 3.0", $"{common}/CatalogosCartaPorte30.xls", importer: typeof(Update.Importers.CartaPorte30Importer)) { AllowUpdate = true },
                new ConstantOrigin("CCP 3.1 - Carta Porte 3.1", $"{common}/CatalogosCartaPorte31.xls", importer: typeof(Update.Importers.CartaPorte31Importer)) { AllowUpdate = true },
                new ConstantOrigin("Artículo 69 No localizados", "https://wu1agsprosta001.blob.core.windows.net/agsc-publicaciones/Datos_abiertos/Documents_AGR/No_localizados.csv", importer:typeof(Update.Importers.Articulo69Importer)){ AllowUpdate = true },
                new ConstantOrigin("Artículo 69-B Listado Completo", "https://wu1agsprosta001.blob.core.windows.net/agsc-publicaciones/Datos_abiertos/Documents_AGAFF/Listado_completo_69-B.csv", importer:typeof(Update.Importers.Articulo69BImporter)) { AllowUpdate = true },
                new ConstantOrigin("Verificación CAPTCHAS", "https://xaxx010101000.s3.dualstack.us-east-1.amazonaws.com/SAT/verificacion/captcha.xml", destinationFilename:@"C:\Jaeger\Jaeger.Catalogos\Captcha.xml", importer: typeof(Update.Importers.StandarImporter)) { AllowUpdate = true },
                new ConstantOrigin("Correos apócrifos identificados", "https://www.sat.gob.mx/minisitio/BuscadorCorreosFalsos/scripts_correos2.js", importer: typeof(Update.Importers.CorreoApocrifoImporter)) { AllowUpdate = true },
                new ConstantOrigin("CCE 2.0 - Claves de pedimento", $"{common}/c_ClavePedimento20.xls"),
                new ConstantOrigin("CCE 2.0 - Colonias", $"{common}/c_Colonia20.xls"),
                new ConstantOrigin("CCE 2.0 - Entidades o estados", $"{common}/C_Estado20.xls"),
                new ConstantOrigin("CCE 1.1 - Fracciones arancelarias 2020", $"{common}/c_FraccionArancelaria.xls", destinationFilename: "c_FraccionArancelaria_20170101.xls"),
                new ScrapingOrigin("CCE 1.1 - Fracciones arancelarias 20201228", "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/catalogos_emision_cfdi_complemento_ce.htm",
                    "c_FraccionArancelaria_20201228.xls",
                    "Catálogo vigente del 28 de diciembre de 2020 al 11 de diciembre de 2022"),
                new ScrapingOrigin("CCE 1.1 - Fracciones arancelarias 20221212", "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/catalogos_emision_cfdi_complemento_ce.htm",
                    "c_FraccionArancelaria_20221212.xls",
                    linkText: "Catálogo vigente a partir del 12 de diciembre de 2022"),
                new ConstantOrigin("CCE 1.1 - Incoterms", $"{common}/c_INCOTERM.xls"),
                new ConstantOrigin("CCE 1.1 - Localidades", $"{common}/c_Localidad.xls"),
                new ConstantOrigin("CCE 1.1 - Motivo traslado", $"{common}/c_MotivoTraslado.xls"),
                new ConstantOrigin("CCE 1.1 - Municipios", $"{common}/c_Municipio.xls"),
                new ConstantOrigin("CCE 1.1 - Tipos de operaciones", $"{common}/c_TipoOperacion.xls"),
                new ConstantOrigin("CCE 1.1 - Unidades de medida", $"{common}/c_UnidadAduana.xls"),
            };
        }

        protected List<IOrigin> Default1() {
            return new List<IOrigin>() {
                new ScrapingOrigin(
                    "CFDI 3.3",
                    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm",
                    "catCFDI33.xls",
                    "Catálogos CFDI Versión 3.3", importer: typeof(Update.Importers.Cfdi33Importer)),
                new ScrapingOrigin(
                        "CFDI 4.0",
                        "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm",
                        "cfdi_40.xls",
                        "Catálogos CFDI Versión 4.0", importer: typeof(Update.Importers.Cfdi40Importer)),
                new ConstantOrigin("Nóminas", $"{common}/catNomina.xls"),
                new ConstantOrigin("Nóminas - Estados", $"{common}/C_Estado.xls", null, "nominas_estados.xls"),
                new ConstantOrigin("CCE 2.0 - Claves de pedimento", $"{common}/c_ClavePedimento20.xls"),
                new ConstantOrigin("CCE 2.0 - Colonias", $"{common}/c_Colonia20.xls"),
                new ConstantOrigin("CCE 2.0 - Entidades o estados", $"{common}/C_Estado20.xls"),
                new ConstantOrigin("CCE 1.1 - Fracciones arancelarias 2020", $"{common}/c_FraccionArancelaria.xls", destinationFilename: "c_FraccionArancelaria_20170101.xls"),
                new ScrapingOrigin(
                    "CCE 1.1 - Fracciones arancelarias 20201228",
                    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/catalogos_emision_cfdi_complemento_ce.htm",
                    "c_FraccionArancelaria_20201228.xls",
                    "Catálogo vigente del 28 de diciembre de 2020 al 11 de diciembre de 2022"
                    ),
                new ScrapingOrigin(
                    "CCE 1.1 - Fracciones arancelarias 20221212",
                    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/catalogos_emision_cfdi_complemento_ce.htm",
                    "c_FraccionArancelaria_20221212.xls",
                    linkText: "Catálogo vigente a partir del 12 de diciembre de 2022"
                    ),
                new ConstantOrigin("CCE 1.1 - Incoterms", $"{common}/c_INCOTERM.xls"),
                new ConstantOrigin("CCE 1.1 - Localidades", $"{common}/c_Localidad.xls"),
                new ConstantOrigin("CCE 1.1 - Motivo traslado", $"{common}/c_MotivoTraslado.xls"),
                new ConstantOrigin("CCE 1.1 - Municipios", $"{common}/c_Municipio.xls"),
                new ConstantOrigin("CCE 1.1 - Tipos de operaciones", $"{common}/c_TipoOperacion.xls"),
                new ConstantOrigin("CCE 1.1 - Unidades de medida", $"{common}/c_UnidadAduana.xls"),
                new ConstantOrigin("REP", $"{common}/catPagos.xls"),
                new ConstantOrigin("CCP 2.0 - Carta Porte 2.0", $"{common}/CatalogosCartaPorte20.xls"),
                new ConstantOrigin("CCP 3.0 - Carta Porte 3.0", $"{common}/CatalogosCartaPorte30.xls"),
                new ConstantOrigin("CCP 3.0 - Carta Porte 3.1", $"{common}/CatalogosCartaPorte31.xls"),
                new ConstantOrigin(
                    "Artículo 69 No localizados",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/No localizados.csv",
                    importer:typeof(Update.Importers.Articulo69Importer)
                    ),
                new ConstantOrigin(
                    "Artículo 69-B Listado Completo",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/Listado_Completo_69-B.csv", importer:typeof(Update.Importers.Articulo69BImporter)
                    ),
                new ConstantOrigin("Manual de Usuario, sitio SAT descarga y recuperacion",
                            "https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1705376527662&ssbinary=true",
                            destinationFilename: "ManualUsuario.pdf"),
                new ConstantOrigin("Descarga y Recuperación de Comprobantes",
                            "https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1705376489587&ssbinary=true",
                            destinationFilename: "DescargaYRecuperacionComprobantes.pdf"),
                new ConstantOrigin("Web service: URL's",
                            "https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1705376489663&ssbinary=true",
                            destinationFilename: "WebserviceURLs.pdf"),
                new ConstantOrigin("Web service: servicio de solicitud de descargas para CFDI y retenciones",
                            "https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1705376527679&ssbinary=true",
                            destinationFilename: "WebServiceSolicitudDescargaCFDIyRetenciones.pdf"),
                new ConstantOrigin("Web service: servicio de descarga de solicitudes exitosas",
                            "https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1705376489610&ssbinary=true",
                            destinationFilename: "WebServiceSolicitudDescargaCFDIyRetencionesExitosas.pdf"),
                new ConstantOrigin("Web service: Servicio de verificación de descarga masiva",
                            "https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1705376527697&ssbinary=true",
                            destinationFilename: "WebServiceSolicitudDescargaCFDIyRetencionesVerificacion.pdf")
            };
        }

        //public static IOrigin GetOrigin(SourceIdentifierEnum source) {
        //    switch (source) {
        //        case SourceIdentifierEnum.CFDIv33:
        //            //return new ScrapingOrigin(
        //            //    "CFDI 3.3",
        //            //    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm",
        //            //    "catCFDI.xls",
        //            //    "Catálogos CFDI Versión 3.3");
        //        case SourceIdentifierEnum.CFDIv40:
        //            return new ScrapingOrigin(
        //                "CFDI 4.0",
        //                "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm",
        //                "cfdi_40.xls",
        //                "Catálogos CFDI Versión 4.0", importer: typeof(Update.Importers.Cfdi40Importer));
        //        case SourceIdentifierEnum.RETv20:
        //            return new ScrapingOrigin(
        //            "RET 2.0",
        //            "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/CFDI_retenciones.htm",
        //            "ret_20.xls",
        //            "Catálogos", importer: typeof(Update.Importers.Retencion20Importer));
        //        case SourceIdentifierEnum.Nomina12:
        //            return new ConstantOrigin("Nóminas", $"{common}/catNomina.xls");
        //        case SourceIdentifierEnum.NominaEstados:
        //            return new ConstantOrigin("Nóminas - Estados", $"{common}/C_Estado.xls", null, "nominas_estados.xls");
        //        case SourceIdentifierEnum.Articulo69:
        //            return new ConstantOrigin(
        //            "Artículo 69 No localizados",
        //            "http://omawww.sat.gob.mx/cifras_sat/Documents/No localizados.csv"
        //            );
        //        case SourceIdentifierEnum.Articulo69B:
        //            return new ConstantOrigin(
        //            "Artículo 69-B Listado Completo",
        //            "http://omawww.sat.gob.mx/cifras_sat/Documents/Listado_Completo_69-B.csv"
        //            );
        //        case SourceIdentifierEnum.CPortev20:
        //            return new ConstantOrigin("CCE 2.0 - Claves de pedimento", $"{common}/c_ClavePedimento20.xls");
        //        case SourceIdentifierEnum.CPortev30:
        //            return new ConstantOrigin("CCP 3.0 - Carta Porte 3.0", $"{common}/CatalogosCartaPorte30.xls");
        //        case SourceIdentifierEnum.CPorteV31:
        //            return new ConstantOrigin("CCP 3.0 - Carta Porte 3.1", $"{common}/CatalogosCartaPorte31.xls");
        //        case SourceIdentifierEnum.REP:
        //            return new ConstantOrigin("REP", $"{common}/catPagos.xls");
        //        default:
        //            break;
        //    }
        //    if (source == SourceIdentifierEnum.CFDIv33) {
        //    } else if (source == SourceIdentifierEnum.CFDIv40) {
        //    }
        //    return null;
        //}
    }
}
