using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class CartaPorte30Catalogos : AbstractXlsImporter, IImporter {
        public CartaPorte30Catalogos(IConfiguration configuration) : base(configuration) {
            this.FileName = "CatalogosCartaPorte30.xls";
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new RegimenesAduaneros(dataSet.Tables["c_RegimenAduanero"]),
                    new Transporte(dataSet.Tables["c_CveTransporte"]),
                    new TipoEstacion(dataSet.Tables["c_TipoEstacion"]),
                    new Estaciones(dataSet.Tables["c_Estaciones "]),
                    new UnidadPeso(dataSet.Tables["c_ClaveUnidadPeso"]),
                    new ProductoServicio(dataSet.Tables["c_ClaveProdServCP"]),
                    new MaterialPeligroso(dataSet.Tables["c_MaterialPeligroso"]),
                    new TipoEmbalaje(dataSet.Tables["c_TipoEmbalaje"]),
                    new TipoPermiso(dataSet.Tables["c_TipoPermiso"]),
                    // Localidad, para este utilizamos en cfdi40
                    // catalogo de municipios utilizamos en cfdi 40
                    new SectorCofepris(dataSet.Tables["c_SectorCOFEPRIS"]),
                    new FormaFarmaceutica(dataSet.Tables["c_FormaFarmaceutica"]),
                    new CondicionesEspeciales(dataSet.Tables["c_CondicionesEspeciales"]),
                    new TipoMateria(dataSet.Tables["c_TipoMateria"]),
                    new DocumentoAduanero(dataSet.Tables["c_DocumentoAduanero"]),
                    new ParteTransporte(dataSet.Tables["c_ParteTransporte"]),
                    new FiguraTransporte(dataSet.Tables["c_FiguraTransporte"]),
                    new ConfigTransporte(dataSet.Tables["c_ConfigAutotransporte"]),
                    new SubTipoRemolque(dataSet.Tables[" c_SubTipoRem"]),
                    new RegistroISTMO(dataSet.Tables["c_RegistroISTMO"]),
                    new ConfigMaritima(dataSet.Tables["c_ConfigMaritima"]),
                    new TipoCarga(dataSet.Tables["c_ClaveTipoCarga"]),
                    new ContenedorMaritimo(dataSet.Tables["c_ContenedorMaritimo"]),
                    new NumAutorizacionNaviero(dataSet.Tables["c_NumAutorizacionNaviero"]),
                    new CodigoTransporteAereo(dataSet.Tables["c_CodigoTransporteAereo"]),
                    new TipoDeServicio(dataSet.Tables["c_TipoDeServicio"]),
                    new DerechosDePaso(dataSet.Tables["c_DerechosDePaso"]),
                    new TipoCarro(dataSet.Tables["c_TipoCarro"]),
                    new Contenedor(dataSet.Tables["c_Contenedor"]),
                    new TipoDeTrafico(dataSet.Tables["c_TipoDeTrafico"]),
                }
            };
        }
    }
}
