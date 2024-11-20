using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catalogo de objeto de impuestos para comprobante fiscal 4.0
    /// </summary>
    public class ObjetoImpRepository : RepositoryContext<CveObjetoImp>, IObjetoImpRepository, IRepositoryGeneric {
        public ObjetoImpRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo Objeto de Impuestos";
            FileName = "ObjetoImpCFDI40.json";
            Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveObjetoImp Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    return new CveObjetoImp() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveObjetoImp { Clave = query };
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<ClaveObjetoImp> {
        //        new ClaveObjetoImp { Clave = "01", Descripcion = "No objeto de impuesto.", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClaveObjetoImp { Clave = "02", Descripcion = "Sí objeto de impuesto.", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClaveObjetoImp { Clave = "03", Descripcion = "Sí objeto del impuesto y no obligado al desglose.", VigenciaIni = new System.DateTime(2022, 1, 1) }
        //    };
        //}
    }
}
