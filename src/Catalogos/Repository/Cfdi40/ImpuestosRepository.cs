using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de impuestos
    /// </summary>
    public class ImpuestosRepository : RepositoryContext<CveImpuesto>, IImpuestosRepository, IGeneralRepository {
        public ImpuestosRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de impuestos";
            FileName = "ImpuestosCFDI40.json";
            Version = "1.0";
            Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveImpuesto Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    return new CveImpuesto() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveImpuesto() { Clave = query };
        }
    }
}
