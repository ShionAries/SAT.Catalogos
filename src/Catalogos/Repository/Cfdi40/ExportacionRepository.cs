using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de exportacion para comprobante fiscal 4.0
    /// </summary>
    public class ExportacionRepository : RepositoryContext<CveExportacion>, IExportacionRepository, IRepositoryGeneric {
        public ExportacionRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo Exportación";
            FileName = "ExportacionCFDi40.json";
            Version = "2.0";
            Revision = "1";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveExportacion Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    return new CveExportacion() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveExportacion() { Clave = query };
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
