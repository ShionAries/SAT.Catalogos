using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de numeros de pedimento operados por aduana y ejercicio.
    /// </summary>
    public class NumPedimentoAduanaRepository : RepositoryContext<CveNumPedimentoAduana>, INumPedimentoAduanaRepository, IGeneralRepository {
        public NumPedimentoAduanaRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de números de pedimento operados por aduana y ejercicio.";
            FileName = "NumPedimentoAduanaCFDI40.json";
            Version = "31.0";
            Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveNumPedimentoAduana Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    return new CveNumPedimentoAduana() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveNumPedimentoAduana() { Clave = query };
        }
    }
}
