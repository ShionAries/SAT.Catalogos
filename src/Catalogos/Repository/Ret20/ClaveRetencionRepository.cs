using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Retenciones
    /// </summary>
    public class ClaveRetencionRepository : RepositoryContext<CveRetencion>, IClaveRetencionRepository, IRepositoryGeneric {
        public ClaveRetencionRepository() {
            Title = "Catálogo de Retenciones";
            FileName = "CarRet20CveRetenciones.json";
            Version = "1";
            Revision = "0";
        }

        public override CveRetencion Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveRetencion { Clave = query };
        }
    }
}
