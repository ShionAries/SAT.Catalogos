using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping {
    public class DumpOrigins {
        protected internal string common = "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/documentos";
        protected internal List<IOriginInterface> _Origins;

        public DumpOrigins() {
            this._Origins = new List<IOriginInterface>() {
                new ScrapingOrigin(
                    "CFDI 3.3",
                    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm",
                    "catCFDI.xls",
                    "Catálogos CFDI Versión 3.3"),
                new ScrapingOrigin(
                    "CFDI 4.0",
                    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm",
                    "cfdi_40.xls",
                    "Catálogos CFDI Versión 4.0"),
                new ScrapingOrigin(
                    "RET 2.0",
                    "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/CFDI_retenciones.htm",
                    "ret_20.xls",
                    "Catálogos"),
                new ConstantOrigin("Nóminas", $"{common}/catNomina.xls"),
                new ConstantOrigin("Nóminas - Estados", $"{common}/C_Estado.xls", null, "nominas_estados.xls"),
                new ConstantOrigin("CCE 2.0 - Claves de pedimento", $"{common}/c_ClavePedimento20.xls"),
                new ConstantOrigin("CCE 2.0 - Colonias", $"{common}/c_Colonia20.xls"),
                new ConstantOrigin("CCE 2.0 - Entidades o estados", $"{common}/C_Estado20.xls"),
                new ConstantOrigin(
                    "CCE 1.1 - Fracciones arancelarias 2020",
                    $"{common}/c_FraccionArancelaria.xls",
                    destinationFilename: "c_FraccionArancelaria_20170101.xls"),
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
                new ConstantOrigin(
                    "Artículo 69 No localizados",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/No localizados.csv"
                    ),
                new ConstantOrigin(
                    "Artículo 69-B Listado Completo",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/Listado_Completo_69-B.csv"
                    )
            };
        }

        public List<IOriginInterface> Origins {
            get { return _Origins; }
            set { this._Origins = value; }
        }
    }
}
