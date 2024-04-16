using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class CartaPorte30Catalogs : AbstractXlsImporter, IImporter {
        public CartaPorte30Catalogs(string csvFolder) : base(csvFolder) {
        }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    //new RegimenesAduaneros(dataSet.Tables["c_RegimenAduanero"]),
                    //new ClavesTransporte(dataSet.Tables["c_CveTransporte"]),
                    //new ClavesTipoEstacion(dataSet.Tables["c_TipoEstacion"]),
                    //new ClavesEstaciones(dataSet.Tables["c_Estaciones "]),
                    //new ClaveUnidadPeso(dataSet.Tables["c_ClaveUnidadPeso"]),
                    //new ClavesProductoServicio(dataSet.Tables["c_ClaveProdServCP"]),
                    //new ClavesMaterialPeligroso(dataSet.Tables["c_MaterialPeligroso"]),
                    //new ClavesTipoEmbalaje(dataSet.Tables["c_TipoEmbalaje"]),
                    //new ClavesTipoPermiso(dataSet.Tables["c_TipoPermiso"]),
                    new SectorCofepris(dataSet.Tables["c_SectorCOFEPRIS"]),
                }
            };
        }
    }
}
