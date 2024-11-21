using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de estados
    /// </summary>
    public class EstadoRepository : RepositoryContext<CveEstado>, IEstadoRepository, IRepositoryGeneric {
        public EstadoRepository() {
            Description = "Catálogo de Estados";
            FileName = "EstadosCFDi40.json";
        }

        public override CveEstado Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Estado == query);
                if (search == null) {
                    return new CveEstado { Estado = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveEstado { Estado = query };
        }
    }
}
