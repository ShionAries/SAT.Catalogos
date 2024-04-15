using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catalogo de objeto de impuestos para comprobante fiscal 4.0
    /// </summary>
    public class ObjetoImpRepository : RepositoryContext<ClaveObjetoImp>, IObjetoImpRepository, IGeneralRepository {
        public ObjetoImpRepository() {
            this.Title = "Catálogo Objeto de Impuestos";
            this.FileName = "ObjetoImpCatalogo.json";
            this.Version = "1.0";
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
