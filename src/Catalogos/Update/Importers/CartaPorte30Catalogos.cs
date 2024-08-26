using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class CartaPorte30Catalogos : AbstractXlsImporter, IImporter {
        public CartaPorte30Catalogos(string csvFolder) : base(csvFolder) {
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new RegimenesAduaneros(dataSet.Tables["c_RegimenAduanero"]),
                    new ClavesTransporte(dataSet.Tables["c_CveTransporte"]),
                    new ClavesTipoEstacion(dataSet.Tables["c_TipoEstacion"]),
                    new ClavesEstaciones(dataSet.Tables["c_Estaciones "]),
                    new ClaveUnidadPeso(dataSet.Tables["c_ClaveUnidadPeso"]),
                    new ClavesProductoServicio(dataSet.Tables["c_ClaveProdServCP"]),
                    new ClavesMaterialPeligroso(dataSet.Tables["c_MaterialPeligroso"]),
                    new ClavesTipoEmbalaje(dataSet.Tables["c_TipoEmbalaje"]),
                    new ClavesTipoPermiso(dataSet.Tables["c_TipoPermiso"]),
                    new SectorCofepris(dataSet.Tables["c_SectorCOFEPRIS"]),
                    new FormaFarmaceutica(dataSet.Tables["c_FormaFarmaceutica"]),
                    new TipoMateria(dataSet.Tables["c_TipoMateria"]),
                    new DocumentoAduanero(dataSet.Tables["c_DocumentoAduanero"]),
                    new ParteTransporte(dataSet.Tables["c_ParteTransporte"]),
                    new FiguraTransporte(dataSet.Tables["c_FiguraTransporte"]),
                    new ConfigTransporte(dataSet.Tables["c_ConfigAutotransporte"]),
                    new SubTipoRemolque(dataSet.Tables[" c_SubTipoRem"]),
                    new ClavesRegistroISTMO(dataSet.Tables["c_RegistroISTMO"]),
                    new ClavesConfigMaritima(dataSet.Tables["c_ConfigMaritima"]),
                    new ClavesTipoCarga(dataSet.Tables["c_ClaveTipoCarga"]),
                    new ClaveContenedorMaritimo(dataSet.Tables["c_ContenedorMaritimo"]),
                    new ClavesNumAutorizacion(dataSet.Tables["c_NumAutorizacionNaviero"]),
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
