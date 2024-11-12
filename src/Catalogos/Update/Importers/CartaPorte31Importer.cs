using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Ccp31;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class CartaPorte31Importer : AbstractXlsImporter, IImporter {
        public CartaPorte31Importer() : base() {
            this.FileName = "CatalogosCartaPorte31.xls";
        }

        public CartaPorte31Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

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
                    new ClaveColoniaInjector(dataSet.Tables["c_Colonia"]),
                    new ClaveLocalidadInjector(dataSet.Tables["c_Localidad"]),
                    new ClaveMunicipioInjector(dataSet.Tables["C_Municipio"]),
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
