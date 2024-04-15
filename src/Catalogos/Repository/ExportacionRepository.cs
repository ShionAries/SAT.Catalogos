using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class ExportacionRepository : RepositoryContext<ClaveExportacion>, IExportacionCatalogo, IGeneralRepository {
        public ExportacionRepository() {
            this.Title = "Catálogo Exportación";
            this.FileName = "ExportacionCatalogo.json";
            this.Version = "2.0";
            this.Revision = "1";
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<ClaveExportacion> {
        //        new ClaveExportacion{ Clave = "01", Descripcion = "No Aplica", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClaveExportacion{ Clave = "02", Descripcion = "Definitiva con clave A1", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClaveExportacion{ Clave = "03", Descripcion = "Temporal", VigenciaIni = new System.DateTime(2022, 1, 1)},
        //        new ClaveExportacion{ Clave = "04", Descripcion = "Definitiva con clave distinta a A1 o cuando no existe enajenación en términos del CFF", VigenciaIni = new System.DateTime(2022, 1, 1)}
        //    };
        //}
    }
}
