using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class CartaPorte30Importer : AbstractXlsImporter, IImporter {
        public CartaPorte30Importer() : base() {
            this.FileName = "CatalogosCartaPorte30.xls";
        }

        public CartaPorte30Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new RegimenesAduanerosInjector(dataSet.Tables["c_RegimenAduanero"]),
                    new TransporteInjector(dataSet.Tables["c_CveTransporte"]),
                    new TipoEstacionInjector(dataSet.Tables["c_TipoEstacion"]),
                    new EstacionesInjector(dataSet.Tables["c_Estaciones "]),
                    new UnidadPesoInjector(dataSet.Tables["c_ClaveUnidadPeso"]),
                    new ProductoServicioInjector(dataSet.Tables["c_ClaveProdServCP"]),
                    new MaterialPeligrosoInjector(dataSet.Tables["c_MaterialPeligroso"]),
                    new TipoEmbalajeInjector(dataSet.Tables["c_TipoEmbalaje"]),
                    new TipoPermisoInjector(dataSet.Tables["c_TipoPermiso"]),
                    // Localidad, para este utilizamos en cfdi40
                    // catalogo de municipios utilizamos en cfdi 40
                    new SectorCofeprisInjector(dataSet.Tables["c_SectorCOFEPRIS"]),
                    new FormaFarmaceuticaInjector(dataSet.Tables["c_FormaFarmaceutica"]),
                    new CondicionesEspecialesInjector(dataSet.Tables["c_CondicionesEspeciales"]),
                    new TipoMateriaInjector(dataSet.Tables["c_TipoMateria"]),
                    new DocumentoAduaneroInjector(dataSet.Tables["c_DocumentoAduanero"]),
                    new ParteTransporteInjector(dataSet.Tables["c_ParteTransporte"]),
                    new FiguraTransporteInjector(dataSet.Tables["c_FiguraTransporte"]),
                    new ConfigTransporteInjector(dataSet.Tables["c_ConfigAutotransporte"]),
                    new SubTipoRemolqueInjector(dataSet.Tables[" c_SubTipoRem"]),
                    new RegistroISTMOInjector(dataSet.Tables["c_RegistroISTMO"]),
                    new ConfigMaritimaInjector(dataSet.Tables["c_ConfigMaritima"]),
                    new TipoCargaInjector(dataSet.Tables["c_ClaveTipoCarga"]),
                    new ContenedorMaritimoInjector(dataSet.Tables["c_ContenedorMaritimo"]),
                    new NumAutorizacionNavieroInjector(dataSet.Tables["c_NumAutorizacionNaviero"]),
                    new CodigoTransporteAereoInjector(dataSet.Tables["c_CodigoTransporteAereo"]),
                    new TipoDeServicioInjector(dataSet.Tables["c_TipoDeServicio"]),
                    new DerechosDePasoInjector(dataSet.Tables["c_DerechosDePaso"]),
                    new TipoCarroInjector(dataSet.Tables["c_TipoCarro"]),
                    new ContenedorInjector(dataSet.Tables["c_Contenedor"]),
                    new TipoDeTraficoInjector(dataSet.Tables["c_TipoDeTrafico"]),
                }
            };
        }
    }
}
