using System.Collections.Generic;
using System.Runtime.Serialization;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping {
    [DataContract]
    public class DumpOrigins {
        protected internal string common = "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/documentos";
        protected internal List<IOriginInterface> _Origins;

        public DumpOrigins() {
            this._Origins = new List<IOriginInterface>() {
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
                new ConstantOrigin("Nóminas", string.Format("{0}/catNomina.xls", common)),
                new ConstantOrigin("Nóminas - Estados", string.Format("{0}/C_Estado.xls", common), null, "nominas_estados.xls"),
                new ConstantOrigin("CCE 2.0 - Claves de pedimento", string.Format("{0}/c_ClavePedimento20.xls", common)),
                new ConstantOrigin("CCE 2.0 - Colonias", string.Format("{0}/c_Colonia20.xls", common)),
                new ConstantOrigin("CCE 2.0 - Entidades o estados", string.Format("{0}/C_Estado20.xls", common)),
                new ConstantOrigin(
                    "CCE 1.1 - Fracciones arancelarias 2020",
                    string.Format("{0}/c_FraccionArancelaria.xls",common),
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
                new ConstantOrigin("CCE 1.1 - Tipos de operaciones", string.Format("{0}/c_TipoOperacion.xls", common)),
                new ConstantOrigin("CCE 1.1 - Unidades de medida", string.Format("{0}/c_UnidadAduana.xls", common)),
                new ConstantOrigin("REP", string.Format("{0}/catPagos.xls", common)),
                new ConstantOrigin("CCP 2.0 - Carta Porte 2.0", string.Format("{0}/CatalogosCartaPorte20.xls", common)),
                new ConstantOrigin("CCP 3.0 - Carta Porte 3.0", string.Format("{0}/CatalogosCartaPorte30.xls", common)),
                new ConstantOrigin(
                    "No localizados",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/No%20localizados.csv"
                    ),
                new ConstantOrigin("Cancelados 69B",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/Cancelados.csv"),
                new ConstantOrigin("Cancelados Artículo 146A del 01 de enero de 2007 al 04 de mayo de 2015",
                    "http://omawww.sat.gob.mx/cifras_sat/Documents/Cancelados_07_15.csv")
            };
        }

        [DataMember]
        public List<IOriginInterface> Origins {
            get { return _Origins; }
            set { this._Origins = value; }
        }
    }
}
